namespace Exceptions;

// Dummy type to enable Example 6 to compile
class RequestFailedException(int status) : Exception
{
    public int Status { get; } = status;
}
