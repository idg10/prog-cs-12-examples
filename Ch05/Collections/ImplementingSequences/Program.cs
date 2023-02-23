static IEnumerable<int> Countdown(int start, int end)
{
    for (int i = start; i >= end; --i)
    {
        yield return i;
    }
}

foreach (int i in Countdown(5, 1))
{
    Console.WriteLine(i);
}
