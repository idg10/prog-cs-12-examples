using System.Numerics;

namespace Virtuals;

public static class StaticVirtuals
{
    public static T Two<T>()
        where T : INumberBase<T>
    {
        return T.One + T.One;
    }

    public static Complex Use() => Two<Complex>();
}

#if false
// This is an excerpt from the .NET runtime library source code. It's in this
// #if false block because we don't actually want to compile it. It's just
// for illustration.

public interface INumberBase<TSelf>
    : IAdditionOperators<TSelf, TSelf, TSelf>,
      ...
{
    /// <summary>Gets the value <c>1</c> for the type.</summary>
    static abstract TSelf One { get; }
    ...
}
#endif