using System.Numerics;

static T Sum<T>(T[] values)
    where T : INumberBase<T>
{
    T total = T.Zero;
    foreach (T value in values)
    {
        total += value;
    }
    return total;
}

Console.WriteLine(Sum([1, 2, 3]));
Console.WriteLine(Sum([1.2, 3.4, 5.6]));
