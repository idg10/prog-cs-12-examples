var withDefault = (int x = 10) => x * 2;

Console.WriteLine(withDefault());
Console.WriteLine(withDefault(21));

EffectOfLambdaWithDefaultArg.UseLambda();

public delegate int WithDefaultDelegate(int x = 10);

public static class EffectOfLambdaWithDefaultArg
{
    public static void UseLambda()
    {
        WithDefaultDelegate withDefault = WithDefaultMethod;
        Console.WriteLine($"Default arg: {withDefault()}");
        Console.WriteLine($"Supplied arg: {withDefault(42)}");
    }

    private static int WithDefaultMethod(int x = 10)
    {
        return x * 2;
    }
}