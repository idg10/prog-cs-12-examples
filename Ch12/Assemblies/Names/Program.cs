using System.Resources;

namespace ResourceExample;

class Program
{
    static void Main()
    {
        var rm = new ResourceManager(
            "ResourceExample.MyResources", typeof(Program).Assembly);
        string colText = rm.GetString("ColString")!;
        Console.WriteLine($"And now in {colText}");
    }
}