using System.Numerics;

static IEnumerable<BigInteger> Fibonacci()
{
    BigInteger n1 = 1;
    BigInteger n2 = 1;
    yield return n1;
    while (true)
    {
        yield return n2;
        BigInteger t = n1 + n2;
        n1 = n2;
        n2 = t;
    }
}

IEnumerable<BigInteger> evenFib = from n in Fibonacci()
                                  where n % 2 == 0
                                  select n;

foreach (BigInteger n in evenFib)
{
    Console.WriteLine(n);
}
