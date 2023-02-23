namespace Sets;

class Program
{
    private static readonly string[] inputs = ["Hello World!", "Hello", "World!", "Hello"];

    static void Main()
    {
        ShowEachDistinctString(inputs);
    }

    public static void ShowEachDistinctString(IEnumerable<string> strings)
    {
        var shown = new HashSet<string>();  // Implements ISet<T>
        foreach (string s in strings)
        {
            if (shown.Add(s))
            {
                Console.WriteLine(s);
            }
        }
    }
}
