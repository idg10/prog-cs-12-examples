namespace Virtuals.DefaultConstraints;

public class Base
{
    public virtual void F<T>(T? t) where T : struct { }
    public virtual void F<T>(T? t) { }
}