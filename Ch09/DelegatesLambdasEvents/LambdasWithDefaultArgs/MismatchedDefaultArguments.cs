namespace LambdasWithDefaultArgs;

internal class MismatchedDefaultArguments
{
    public static void Mismatched()
    {
        // Remove this next pragma to see the warnings the following code would normally get
#pragma warning disable CS9099,IDE0059,IDE0039

        // The compiler generates a delegate type with a default argument of 10.
        var withDefault = (int x = 10) => x * 2;

        // Warning because this has a different default value (20) than withDefault's
        // compiler-generated delegate type.
        withDefault = (int x = 20) => x + 2;

        // The WithDefaultDelegate delegate defined in a previous example also
        // specifies a default argument of 10 so this also generates a warning.
        WithDefaultDelegate c = (int x = 20) => x - 1;

        // Also warns, because the delegate type does not specify a default argument,
        // but the lambda does.
        Func<int, int> f = (int x = 20) => x + 3;
    }
}
