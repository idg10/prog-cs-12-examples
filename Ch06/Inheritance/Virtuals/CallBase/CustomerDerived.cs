using Library;

namespace Virtuals.CallBase;

public class CustomerDerived : LibraryBase
{
    public override void Start()
    {
        Console.WriteLine("CustomerDerived starting");
        base.Start();
    }
}
