namespace Constructors.Primary;

// Comment this line out to see the diagnostic the compiler usually produces when code
// makes the mistake that this example illustrates.
#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.

public class StoresNameTwice(string name)
{
    private readonly string _name = name;

    public override string ToString() => name; // Captures name
}
