using System.Reactive;
using System.Reactive.Linq;

namespace Timed;

public static class Timers
{
    public static void Timestamped()
    {
        IObservable<Timestamped<long>> src =
            Observable.Interval(TimeSpan.FromSeconds(1)).Timestamp();
        src.Subscribe(i => Console.WriteLine(
            $"Event {i.Value} at {i.Timestamp.ToLocalTime():T}"));
    }
}