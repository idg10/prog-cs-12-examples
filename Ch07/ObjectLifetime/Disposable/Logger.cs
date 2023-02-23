namespace Disposable;

public sealed class Logger(string filePath) : IDisposable
{
    private StreamWriter? _file = File.CreateText(filePath);

    public void Dispose()
    {
        if (_file != null)
        {
            _file.Dispose();
            _file = null;
        }
    }
    // A real class would go on to do something with the StreamWriter, of course
}
