namespace Virtuals.DefaultConstraints;

public class BaseWithSignaturesMadeClear
{
    public virtual void F<T>(Nullable<T> t) where T : struct { }
    public virtual void F<T>(T? t) { }
}
