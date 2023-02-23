using ClassWithStaticMembers;

var c1 = new CounterWithTotal();
var c2 = new CounterWithTotal();
Console.WriteLine($"c1: {c1.GetNextValue()}");
Console.WriteLine($"c1: {c1.GetNextValue()}");
Console.WriteLine($"c1: {c1.GetNextValue()}");

Console.WriteLine($"c2: {c2.GetNextValue()}");

Console.WriteLine($"c1: {c1.GetNextValue()}");

Console.WriteLine(CounterWithTotal.TotalCount);
