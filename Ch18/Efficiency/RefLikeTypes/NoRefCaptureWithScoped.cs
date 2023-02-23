namespace RefLikeTypes;

public readonly ref struct NoRefCaptureWithScoped<T>
{
    public void UseRef(scoped RefLike<T> rv1, scoped RefLike<T> rv2)
    {
        rv1.Ref = rv2.Ref;
    }
}
