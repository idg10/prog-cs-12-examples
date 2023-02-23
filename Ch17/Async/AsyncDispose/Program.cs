await using (DiagnosticWriter w = new(@"c:\temp\log.txt"))
{
    await w.LogAsync("Test");
}

class DiagnosticWriter : IAsyncDisposable
{
    private StreamWriter? _sw;

    public DiagnosticWriter(string path)
    {
        _sw = new StreamWriter(path);
    }

    public Task LogAsync(string message)
    {
        ObjectDisposedException.ThrowIf(_sw is null, nameof(DiagnosticWriter));
        return _sw.WriteLineAsync(message);
    }

    public async ValueTask DisposeAsync()
    {
        if (_sw is not null)
        {
            await LogAsync("Done");
            await _sw.DisposeAsync();
            _sw = null;
        }
    }
}
