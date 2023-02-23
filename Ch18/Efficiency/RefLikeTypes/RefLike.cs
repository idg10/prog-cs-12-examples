namespace RefLikeTypes;

public readonly ref struct RefLike<T>(ref T rv)
{
    public readonly ref T Ref = ref rv;
}
