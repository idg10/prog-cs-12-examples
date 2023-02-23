namespace GenericMath;

// This is a shortened version of this interface for illustration. The real
// one is built into the .NET runtime library. Since we want to use that real
// one in the examples, this is disable with #if false
#if false
public interface IAdditionOperators<TSelf, TOther, TResult>
    where TSelf : IAdditionOperators<TSelf, TOther, TResult>?
{
    static abstract TResult operator +(TSelf left, TOther right);
    static virtual TResult operator checked +(TSelf left, TOther right) => left + right;
}
#endif
