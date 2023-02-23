namespace FundamentalInterfaces;

public class SimpleColdSource : IObservable<string>
{
    public IDisposable Subscribe(IObserver<string> observer)
    {
        observer.OnNext("Hello,");
        observer.OnNext("World!");
        observer.OnCompleted();
        return EmptyDisposable.Instance;
    }

    private class EmptyDisposable : IDisposable
    {
        public readonly static EmptyDisposable Instance = new();
        public void Dispose() { }
    }
}