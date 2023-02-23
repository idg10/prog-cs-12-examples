namespace Constraints;

// For illustration only. Consider using Lazy<T> in a real program.
public static class Deferred<T>
    where T : new()
{
    private static T? _instance;

    public static T Instance => _instance ??= new T();
}
