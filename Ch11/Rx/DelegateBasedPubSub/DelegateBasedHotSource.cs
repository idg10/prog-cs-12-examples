using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DelegateBasedPubSub;

public class DelegateBasedHotSource
{
    public static void Run()
    {
        IObservable<char> singularHotSource = Observable.Create(
            (Func<IObserver<char>, IDisposable>)(observer =>
            {
                while (true)
                {
                    observer.OnNext(Console.ReadKey(true).KeyChar);
                }
            }));

        IConnectableObservable<char> keySource = singularHotSource.Publish();

        keySource.Subscribe(new MySubscriber<char>());
        keySource.Subscribe(new MySubscriber<char>());

        keySource.Connect();
    }
}