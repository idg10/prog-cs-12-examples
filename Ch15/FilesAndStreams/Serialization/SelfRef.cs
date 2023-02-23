namespace Serialization;

public class SelfRef
{
    public required string Name { get; set; }
    public SelfRef? Next { get; set; }
}