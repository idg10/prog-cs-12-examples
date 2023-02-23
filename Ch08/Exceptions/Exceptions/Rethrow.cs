namespace Exceptions;

class Rethrow
{
    public static void BadRethrow()
    {
#pragma warning disable CA2200 // Rethrow to preserve stack details - this example exists to illustrate the problem that CA2200 detects
        try
        {
            DoSomething();
        }
        catch (IOException ex)
        {
            LogIOError(ex);
            // This next line is BAD!
            throw ex;  // Do not do this
        }
#pragma warning restore CA2200 // Rethrow to preserve stack details
    }

    public static void GoodRethrow()
    {
        try
        {
            DoSomething();
        }
        catch (IOException ex)
        {
            LogIOError(ex);
            throw;
        }
    }

    private static void DoSomething()
    {
    }

    private static void LogIOError(IOException ex)
    {
    }
}
