namespace Threading;

public class Notifier(Action callback)
{
    private readonly ThreadLocal<bool> _isCallbackInProgress = new();

    public void Notify()
    {
        if (_isCallbackInProgress.Value)
        {
            throw new InvalidOperationException(
                "Notification already in progress on this thread");
        }

        try
        {
            _isCallbackInProgress.Value = true;
            callback();
        }
        finally
        {
            _isCallbackInProgress.Value = false;
        }
    }
}
