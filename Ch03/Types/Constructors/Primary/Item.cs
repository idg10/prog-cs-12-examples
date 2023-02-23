namespace Constructors.Primary;

public class Item(decimal price, string name)
{
    public override string ToString() => $"{name}: {price:C}";
}
