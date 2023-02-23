namespace CustomAttributes;

[AttributeUsage(AttributeTargets.Class)]
public class PluginInformationAttribute(string name, string author) : Attribute
{
    public string Name { get; } = name;

    public string Author { get; } = author;

    public string? Description { get; set; }
}