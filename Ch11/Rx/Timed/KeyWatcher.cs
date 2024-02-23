﻿namespace Timed;

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

    private class Subscription : IDisposable
    {
        private KeyWatcher? _parent;
        public Subscription(KeyWatcher parent, IObserver<char> observer)
        {
            _parent = parent;
            Observer = observer;
        }

        public IObserver<char> Observer { get; }

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