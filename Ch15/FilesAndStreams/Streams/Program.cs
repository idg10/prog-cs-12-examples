namespace Streams;

class Program
{
    static void Main()
    {
    }
}

// Members of Stream for illustration purposes only. These are defined by .NET so
// we don't need to define them ourselves.
#if false
public abstract int Read(byte[] buffer, int offset, int count);
public abstract void Write(byte[] buffer, int offset, int count);
public abstract long Position { get; set; }

public abstract long Seek(long offset, SeekOrigin origin);
#endif
