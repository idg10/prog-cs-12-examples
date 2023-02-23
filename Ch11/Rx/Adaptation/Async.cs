using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace Adaptation;

public static class Async
{
    public static class FetchOnce
    {
        public static IObservable<string> GetWebPageAsObservable(
            Uri pageUrl, IHttpClientFactory cf)
        {
            async Task<string> GetPageAsync()
            {
                using HttpClient web = cf.CreateClient();
                return await web.GetStringAsync(pageUrl).ConfigureAwait(false);
            }
            return GetPageAsync().ToObservable();
        }
    }

    public static class FetchPerSubscriber
    {
        public static IObservable<string> GetWebPageAsObservable(
            Uri pageUrl, IHttpClientFactory cf)
        {
            return Observable.FromAsync(async () =>
            {
                using HttpClient web = cf.CreateClient();
                return await web.GetStringAsync(pageUrl);
            });
        }
    }
}