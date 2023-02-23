namespace Structs;

public class LocationData(string label, Point location)
{
    public string Label { get; } = label;
    public Point Location { get; } = location;
}
