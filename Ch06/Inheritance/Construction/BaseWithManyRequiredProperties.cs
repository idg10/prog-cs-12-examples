namespace Construction;

public record BaseWithManyRequiredProperties
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required double Width { get; init; }
}

public record MoreRequiredProps : BaseWithManyRequiredProperties
{
    public required int X { get; init; }
}


public record YetMoreProps : MoreRequiredProps
{
    public required int Y { get; init; }
}

public record EvenMoreProps : MoreRequiredProps
{
    public required int Z { get; init; }
}
