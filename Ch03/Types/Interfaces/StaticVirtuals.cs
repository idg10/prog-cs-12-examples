
namespace Interfaces;

public interface ITotalCount
{
    static abstract int TotalCount { get; }
}

public interface IHanded
{
    static virtual string Side => "Right";
}

public class LeftHanded : IHanded
{
    public static string Side => "Left";
}


public class DefaultHandedness : IHanded
{
}

public static class UseHandedness
{
    public static void ShowHandedness<T>() where T : IHanded
    {
        Console.WriteLine(T.Side);
    }
}