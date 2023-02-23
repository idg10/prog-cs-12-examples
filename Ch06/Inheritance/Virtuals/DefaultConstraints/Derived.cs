namespace Virtuals.DefaultConstraints;

public class Derived : Base
{
    // This overrides the method with the where T : struct constraint
    public override void F<T>(T? t) { }

    // This overrides the method where T is unconstrained.
    public override void F<T>(T? t) where T : default { }
}
