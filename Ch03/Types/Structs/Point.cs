namespace Structs;

public readonly struct Point(double x, double y) : IEquatable<Point>
{
    public double X => x;
    public double Y => y;

    public double DistanceFromOrigin() => Math.Sqrt(X * X + Y * Y);

    public override bool Equals(object? o) => o is Point p && this.Equals(p);
    public bool Equals(Point o) => this.X == o.X && this.Y == o.Y;
    public override int GetHashCode() => HashCode.Combine(X, Y);

    public static bool operator ==(Point a, Point b) => a.Equals(b);
    public static bool operator !=(Point a, Point b) => !(a == b);
}
