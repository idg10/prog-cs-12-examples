namespace Constructors.Primary;

public class CounterWithPrimaryConstructor(int count)
{
    public int GetNextValue()
    {
        count += 1;
        return count;
    }
}