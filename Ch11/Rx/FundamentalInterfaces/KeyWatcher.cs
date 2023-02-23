namespace FundamentalInterfaces;

public class KeyWatcher : IObservable<char>
{
    private readonly List<Subscription> _subscriptions = new();

    public IDisposable Subscribe(IObserver<char> observer)
    {
        var sub = new Subscription(this, observer);
        _subscriptions.Add(sub);
        return sub;
    }

    public void Run()
    {
        while (true)
        {
            // Passing true here stops the console from showing the character
            char c = Console.ReadKey(true).KeyChar;

            // ToArray duplicates the list, enabling us to iterate over a
            // snapshot of our subscribers. This avoids errors when an
            // observer unsubscribes from inside its OnNext method.
            foreach (Subscription sub in _subscriptions.ToArray())
            {
                sub.Observer.OnNext(c);
            }
        }
    }

    private class Subscription(KeyWatcher parent, IObserver<char> observer) : IDisposable
    {
        private KeyWatcher? _parent = parent;

        public IObserver<char> Observer { get; } = observer;

        public void Dispose()
        {
            if (_parent != null)
            {
                _parent._subscriptions.Remove(this);
                _parent = null;
            }
        }
    }
}