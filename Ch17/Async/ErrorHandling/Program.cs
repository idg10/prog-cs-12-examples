using Microsoft.Extensions.DependencyInjection;

namespace ErrorHandling
{
    class Program
    {
        private readonly IHttpClientFactory clientFactory;

        private Program()
        {
            var services = new ServiceCollection();
            services.AddHttpClient();
            this.clientFactory = services.BuildServiceProvider().GetRequiredService<IHttpClientFactory>();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static async Task<string> FindLongestLineAsync(
            string url, IHttpClientFactory cf)
        {
            using (HttpClient w = cf.CreateClient())
            {
                Stream body = await w.GetStreamAsync(url);
                using (var bodyTextReader = new StreamReader(body))
                {
                    string longestLine = string.Empty;
                    while (!bodyTextReader.EndOfStream)
                    {
                        string? line = await bodyTextReader.ReadLineAsync();
                        if (line is not null && line.Length > longestLine.Length)
                        {
                            longestLine = line;
                        }
                    }
                    return longestLine;
                }
            }
        }

        private async Task HandleExceptions()
        {
            try
            {
                string longest = await FindLongestLineAsync(
                    "http://192.168.22.1/", this.clientFactory);
                Console.WriteLine($"Longest line: {longest}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching page: {ex.Message}");
            }
        }

        class PotentiallySurprising
        {
            public async Task<string> FindLongestLineAsync(string url)
            {
                ArgumentNullException.ThrowIfNull(url);

                await Task.Yield();
                return "";
            }
        }

        class ThrowImmediately
        {
            public static Task<string> FindLongestLineAsync(string url)
            {
                ArgumentNullException.ThrowIfNull(url);
                return FindLongestLineCore(url);

                static async Task<string> FindLongestLineCore(string url)
                {
                    return await Program.FindLongestLineAsync(url, new Program().clientFactory);
                }
            }
        }

        static async Task CatchAll(Task[] ts)
        {
            try
            {
                var t = Task.WhenAll(ts);
                await t.ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing);
                t.Wait();
            }
            catch (AggregateException all)
            {
                Console.WriteLine(all);
            }
        }

        static async Task GetSeveral(IHttpClientFactory cf)
        {
            using (HttpClient w = cf.CreateClient())
            {
                w.MaxResponseContentBufferSize = 2_000_000;

                Task<string> g1 = w.GetStringAsync("https://endjin.com/");
                Task<string> g2 = w.GetStringAsync("https://oreilly.com");

                // BAD!
                Console.WriteLine((await g1).Length);
                Console.WriteLine((await g2).Length);
            }
        }
    }
}