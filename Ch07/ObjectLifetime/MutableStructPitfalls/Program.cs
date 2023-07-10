﻿static void CallDispose(IDisposable o)
{
    o.Dispose();
}

DisposableValue dv = new();
Console.WriteLine("Passing value variable:");
CallDispose(dv);
CallDispose(dv);
CallDispose(dv);

IDisposable id = dv;
Console.WriteLine("Passing interface variable:");
CallDispose(id);
CallDispose(id);
CallDispose(id);

Console.WriteLine("Calling Dispose directly on value variable:");
dv.Dispose();
dv.Dispose();
dv.Dispose();

Console.WriteLine("Passing value variable:");
CallDispose(dv);
CallDispose(dv);
CallDispose(dv);

public struct DisposableValue : IDisposable
{
    private bool _disposedYet;

    public void Dispose()
    {
        if (!_disposedYet)
        {
            Console.WriteLine("Disposing for first time");
            _disposedYet = true;
        }
        else
        {
            Console.WriteLine("Was already disposed");
        }
    }
}