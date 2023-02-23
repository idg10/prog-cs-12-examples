namespace Constructors.Simple;

#pragma warning disable IDE0290 // The SDK wants us to use a primary constructor, but this example illustrates the older approach

public class Item
{
    public Item(decimal price, string name)
    {
        _price = price;
        _name = name;
    }
    private readonly decimal _price;
    private readonly string _name;
}
