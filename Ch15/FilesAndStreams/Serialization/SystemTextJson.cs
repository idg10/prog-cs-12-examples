using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Serialization;

public class SystemTextJson
{
    private static readonly JsonSerializerOptions SerializeIndented =
        new() { WriteIndented = true };
    public static string SerializeJson()
    {
        var model = new SimpleData
        {
            Id = 42,
            Names = ["Bell", "Stacey", "her", "Jane"],
            Location = new NestedData
            {
                LocationName = "London",
                Latitude = 51.503209,
                Longitude = -0.119145
            },
            Map = new Dictionary<string, int>
            {
                { "Answer", 42 },
                { "FirstPrime", 2 }
            }
        };

        return JsonSerializer.Serialize(model, SerializeIndented);
    }

    public static void DeserializewJson(string json)
    {
        var deserialized = JsonSerializer.Deserialize<SimpleData>(json);
        if (deserialized is not null)
        {
            Console.WriteLine(deserialized?.Id);
        }

        using (JsonDocument document = JsonDocument.Parse(json))
        {
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                Console.WriteLine($"Property: {property.Name} ({property.Value.ValueKind})");
            }
        }

        using (JsonDocument document = JsonDocument.Parse(json))
        {
            JsonElement namesElement = document.RootElement.GetProperty("names");
            foreach (JsonElement name in namesElement.EnumerateArray())
            {
                Console.WriteLine($"Name: {name.GetString()}");
            }

            JsonElement root = document.RootElement;
            if (root.TryGetProperty("location", out JsonElement locationElement))
            {
                JsonElement nameElement = locationElement.GetProperty("locationName");
                JsonElement latitudeElement = locationElement.GetProperty("latitude");
                JsonElement longitudeElement = locationElement.GetProperty("longitude");
                string locationName = nameElement.GetString()!;
                double latitude = latitudeElement.GetDouble();
                double longitude = longitudeElement.GetDouble();
                Console.WriteLine($"Location: {locationName}: {latitude},{longitude}");
            }
        }

        JsonNode rootNode = JsonNode.Parse(json)!;
        JsonNode mapNode = rootNode["map"]!;
        mapNode["iceCream"] = 99;
    }

    private static readonly JsonSerializerOptions camelCaseOptions =
        new(JsonSerializerDefaults.Web) { WriteIndented = true };
    public static string AutoCamelCase(SimpleData model)
    {
        return JsonSerializer.Serialize(
            model,
            camelCaseOptions);
    }

    private static readonly JsonSerializerOptions jsonWithRefs =
        new(JsonSerializerDefaults.Web)
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve
        };
    public static string SerializeWithCircularReferences()
    {
        var circle = new SelfRef
        {
            Name = "Top",
            Next = new SelfRef
            {
                Name = "Bottom",
            }
        };
        circle.Next.Next = circle;
        string json = JsonSerializer.Serialize(circle, jsonWithRefs);

        return json;
    }

    public static void UseCodeGenDeserialization(string json)
    {
        SimpleData? data = JsonSerializer.Deserialize(
            json, CodeGenSerializationContext.Default.SimpleData);
        Console.WriteLine(data?.Id ?? -1);
    }

    public class SimpleData
    {
        public required int Id { get; set; }
        public required IList<string> Names { get; set; }
        public required NestedData Location { get; set; }
        public required IDictionary<string, int> Map { get; set; }
    }

    public class NestedData
    {
        public required string LocationName { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }
    }
}
