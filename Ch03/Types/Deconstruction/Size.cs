namespace Deconstruction;

public readonly struct Size(double w, double h)
{
    public void Deconstruct(out double w, out double h)
    {
        w = W;
        h = H;
    }

    public double W { get; } = w;
    public double H { get; } = h;
}
