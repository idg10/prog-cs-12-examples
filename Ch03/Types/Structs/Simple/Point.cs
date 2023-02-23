namespace Structs.Simple;

public readonly struct Point(double x, double y)
{
    public double X => x;
    public double Y => y;

    public double DistanceFromOrigin() => Math.Sqrt(X * X + Y * Y);
}
