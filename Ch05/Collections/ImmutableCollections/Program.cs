using System.Collections.Frozen;
using System.Collections.Immutable;

namespace ImmutableCollections;

class Program
{
    static void Main()
    {
        Create();
        CreateWithBuilder();
    }

    public static void Create()
    {
        IImmutableDictionary<int, string> d = ImmutableDictionary.Create<int, string>();
        d = d.Add(1, "One");
        d = d.Add(2, "Two");
        d = d.Add(3, "Three");

        System.Console.WriteLine(d[2]);
    }

    public static void CreateWithBuilder()
    {
        ImmutableDictionary<int, string>.Builder b =
            ImmutableDictionary.CreateBuilder<int, string>();
        b.Add(1, "One");
        b.Add(2, "Two");
        b.Add(3, "Three");
        IImmutableDictionary<int, string> d = b.ToImmutable();

        System.Console.WriteLine(d[2]);
    }

    public static void CreateListWithCollectionExpression()
    {
        ImmutableList<int> numbers = [1, 2, 3, 4, 5];
    }

    public static void UseFrozenCollections()
    {
        Dictionary<int, string> ordinary = GetOrdinaryDictionary();
        FrozenDictionary<int, string> frozen = ordinary.ToFrozenDictionary();

        Console.WriteLine(frozen[1]);
    }

    private static Dictionary<int, string> GetOrdinaryDictionary() => new()
    {
        { 1, "One" },
        { 2, "Two" },
        { 3, "Three" },
    };
}
