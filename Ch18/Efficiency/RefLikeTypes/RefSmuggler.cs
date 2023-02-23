namespace RefLikeTypes;

#pragma warning disable IDE0052 // Remove unread private members - _ref present only for illustration

public ref struct RefSmuggler<T>
{
    private ref T _ref;

    public void ChangeTarget(RefLike<T> rv)
    {
        _ref = ref rv.Ref;
    }
}
