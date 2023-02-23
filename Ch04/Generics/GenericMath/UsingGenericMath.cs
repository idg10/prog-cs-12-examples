using System.Numerics;

namespace GenericMath;

public static class UsingGenericMath
{
    public static T Add<T>(T x, T y)
        where T : INumber<T>
    {
        return x + y; // No error, because INumber<T> requires + to be available
    }
}
