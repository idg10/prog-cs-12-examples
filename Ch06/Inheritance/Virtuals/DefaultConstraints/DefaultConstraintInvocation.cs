namespace Virtuals.DefaultConstraints;

public class DefaultConstraintInvocation
{
    public static void Invoke()
    {
        Base b = new();
        int? nullInt = null;
        int? nonNullNullableInt = 42;

        // These call the 1st overload.
        b.F(nullInt);
        b.F(nonNullNullableInt);
        b.F(default(int?));

        // These call the 2nd overload.
        b.F(42);
        b.F("Hello");
        b.F(default(int));

        // This would cause a compiler error.
        // b.F(null);
    }
}
