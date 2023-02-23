using System.Numerics;

namespace GenericMath;

public static class AdditiveIdentity
{
    public static T Sum<T>(T[] values)
        where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        T total = T.AdditiveIdentity;
        foreach (T value in values)
        {
            total += value;
        }
        return total;
    }
}
