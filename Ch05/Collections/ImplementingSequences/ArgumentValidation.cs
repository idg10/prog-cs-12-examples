using System.Numerics;

namespace ImplementingSequences;

public class ArgumentValidation
{
    public static IEnumerable<BigInteger> Fibonacci(int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        return Core(count);

        static IEnumerable<BigInteger> Core(int count)
        {
            BigInteger v1 = 1;
            BigInteger v2 = 1;

            for (int i = 0; i < count; ++i)
            {
                yield return v1;
                BigInteger tmp = v2;
                v2 = v1 + v2;
                v1 = tmp;
            }
        }
    }
}
