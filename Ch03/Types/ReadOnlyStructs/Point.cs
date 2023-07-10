﻿namespace ReadOnlyStructs;

public readonly struct Point
{
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }
    public double DistanceFromOrigin() => Math.Sqrt(X * X + Y * Y);
}
