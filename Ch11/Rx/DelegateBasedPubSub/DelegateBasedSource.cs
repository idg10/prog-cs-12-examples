using System.Reactive.Linq;

namespace DelegateBasedPubSub;

public static class DelegateBasedSource
{
    public static IObservable<string> GetFilePusher(string path)
    {
        return Observable.Create<string>(async (observer, cancel) =>
        {
            using (var sr = new StreamReader(path))
            {
                while (await sr.ReadLineAsync(cancel) is string line)
                {
                    observer.OnNext(line);
                }
            }
            observer.OnCompleted();
        });
    }
}