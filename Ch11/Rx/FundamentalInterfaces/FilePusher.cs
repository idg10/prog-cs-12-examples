namespace FundamentalInterfaces;

public class FilePusher : IObservable<string>
{
    private readonly string _path;
    public FilePusher(string path)
    {
        _path = path;
    }

    public IDisposable Subscribe(IObserver<string> observer)
    {
        using (var sr = new StreamReader(_path))
        {
            while (sr.ReadLine() is string line) // Repeats until null returned
            {
                observer.OnNext(line);
            }
        }
        observer.OnCompleted();
        return EmptyDisposable.Instance;
    }

    private class EmptyDisposable : IDisposable
    {
        public static EmptyDisposable Instance = new();
        public void Dispose() { }
    }
}