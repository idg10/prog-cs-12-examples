using System.Numerics;

namespace ImplementingSequences;

internal class Iterators
{
    public static IEnumerable<int> ThreeNumbers()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }

    public static IEnumerable<BigInteger> Fibonacci()
    {
        BigInteger v1 = 1;
        BigInteger v2 = 1;

        while (true)
        {
            yield return v1;
            BigInteger tmp = v2;
            v2 = v1 + v2;
            v1 = tmp;
        }
    }
}
