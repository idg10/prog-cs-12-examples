namespace Properties.Auto;

public readonly struct Point(double x, double y)
{
    public double X { get; init; } = x;
    public double Y { get; init; } = y;
}
