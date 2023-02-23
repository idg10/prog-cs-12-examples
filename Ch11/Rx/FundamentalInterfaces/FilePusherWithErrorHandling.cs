namespace FundamentalInterfaces;

public class FilePusherWithErrorHandling : IObservable<string>
{
    private readonly string _path;
    public FilePusherWithErrorHandling(string path)
    {
        _path = path;
    }

    public IDisposable Subscribe(IObserver<string> observer)
    {
        StreamReader? sr = null;
        string? line = null;

        try
        {
            while (true)
            {
                try
                {
                    sr ??= new StreamReader(_path);
                    line = sr.ReadLine();
                }
                catch (IOException ex)
                {
                    observer.OnError(ex);
                    break;
                }

                if (line is not null)
                {
                    observer.OnNext(line);
                }
                else
                {
                    observer.OnCompleted();
                    break;
                }
            }
        }
        finally
        {
            sr?.Dispose();
        }
        return EmptyDisposable.Instance;
    }

    private class EmptyDisposable : IDisposable
    {
        public static EmptyDisposable Instance = new();
        public void Dispose() { }
    }
}