using System.Reactive;
using System.Reactive.Linq;

namespace Adaptation;

public static class Events
{
    public static void Wrapping()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var w = new FileSystemWatcher(path);
        IObservable<EventPattern<FileSystemEventArgs>> changes =
            Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                h => w.Changed += h, h => w.Changed -= h);
        w.IncludeSubdirectories = true;
        w.EnableRaisingEvents = true;

        changes.Subscribe(evt => Console.WriteLine(evt.EventArgs.FullPath));
    }
}