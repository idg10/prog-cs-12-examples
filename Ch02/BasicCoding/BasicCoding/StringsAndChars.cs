using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace BasicCoding;

static class StringsAndChars
{
    const string name = "Ian";
    const int age = 46;

    internal static void CharactersVsChars()
    {
        char[] chars = ['c', 'a', 'f', 'e', (char)0x301, 's'];
        string text = new string(chars);

        Console.WriteLine(text);
    }

    internal static void ExpressionsInStrings()
    {
        string message = $"{name} is {age} years old";

        double width = 3, height = 4;
        string info = $"Hypotenuse: {Math.Sqrt(width * width + height * height)}";

        Console.WriteLine(message);
        Console.WriteLine(info);
    }

    internal static void StringInterpolationEffect()
    {
        double width = 3, height = 4;

        string message = string.Format("{0} is {1} years old", name, age);
        string info = string.Format(
            "Hypotenuse: {0}",
            Math.Sqrt(width * width + height * height));

        Console.WriteLine(message);
        Console.WriteLine(info);
    }

    internal static void FormatSpecifiers()
    {
        string message = $"{name} is {age:f1} years old";

        Console.WriteLine(message);
    }

    internal static void FormatSpecifiersInvariantCulture()
    {
        decimal v = 1234567.654m;
        string i = string.Create(CultureInfo.InvariantCulture, $"Quantity {v:N}");
        string f = string.Create(new CultureInfo("fr"), $"Quantity {v:N}");
        string frc = string.Create(new CultureInfo("fr-FR"), $"Quantity {v:C}");
        string cac = string.Create(new CultureInfo("fr-CA"), $"Quantity {v:C}");
    }

    internal static void PotentiallyUnusedInterpolatedString(
        object myApplicationModel,
        bool everythingIsOk)
    {
        Debug.Assert(everythingIsOk, $"Everything is *not* OK: {myApplicationModel}");
    }

    internal static void Utf8Literals()
    {
        using JsonDocument doc = JsonDocument.Parse("""{ "latitude": 51.50853000, "longitude": -0.12574000}""");
        JsonElement root = doc.RootElement;
        string locationName = "London";

        if (root.TryGetProperty("location"u8, out JsonElement locationElement))
        {
            JsonElement latitudeElement = locationElement.GetProperty("latitude"u8);
            JsonElement longitudeElement = locationElement.GetProperty("longitude"u8);
            double latitude = latitudeElement.GetDouble();
            double longitude = longitudeElement.GetDouble();
            Console.WriteLine($"Location: {locationName}: {latitude},{longitude}");
        }
    }
}
