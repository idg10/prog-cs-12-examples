using System.Reflection;

namespace ReflectionTypes;

public static class DynamicConstruction
{
    public static void Create()
    {
        Assembly asm = typeof(DynamicConstruction).Assembly;

        object? o = asm.CreateInstance(
            "MyApp.WithConstructor",
            false,
            BindingFlags.Public | BindingFlags.Instance,
            null,
            ["Constructor argument"],
            null,
            null);
    }
}
