namespace RefLikeTypes;

public readonly ref struct NoRefCapture<T>
{
    public void UseRef(RefLike<T> rv1, RefLike<T> rv2)
    {
        rv1.Ref = rv2.Ref;
    }
}
