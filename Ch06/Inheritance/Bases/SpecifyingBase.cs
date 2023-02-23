namespace Bases;

public class SomeClass
{
}

public class Derived : SomeClass
{
}

public class DerivedWithPrimaryConstructor(int value) : SomeClass
{
    public override string ToString() => value.ToString();
}

public class AlsoDerived : SomeClass, IDisposable
{
    public void Dispose() { }
}