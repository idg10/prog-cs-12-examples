namespace Delegates;

public class ThresholdComparer
{
    public required int Threshold { get; init; }

    public bool IsGreaterThan(int value) => value > Threshold;

    public Predicate<int> GetIsGreaterThanPredicate() => IsGreaterThan;
}
