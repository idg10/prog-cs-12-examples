using Constructors.Primary;
using Item = Constructors.Simple.Item;

var item1 = new Item(9.99M, "Hammer");

Console.WriteLine(item1);

Item item2 = new(9.99M, "Hammer");

// Change to #if true to see compilation error
#if false
static void WillNotCompile()
{
Uri oops = new Uri();  // Will not compile
}
#endif

var c1 = new CounterWithPrimaryConstructor(0);
var c2 = new CounterWithPrimaryConstructor(10);
Console.WriteLine($"c1: {c1.GetNextValue()}");
Console.WriteLine($"c1: {c1.GetNextValue()}");
Console.WriteLine($"c1: {c1.GetNextValue()}");

Console.WriteLine($"c2: {c2.GetNextValue()}");

Console.WriteLine($"c1: {c1.GetNextValue()}");