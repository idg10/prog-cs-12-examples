namespace GenericTypes;

public class NamedContainer<T>(T item, string name)
{
    public T Item { get; } = item;
    public string Name { get; } = name;
}
