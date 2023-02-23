using System.Text.Json.Serialization;

namespace Serialization;

public class WithAttributes
{
    public class NestedData
    {
        [JsonPropertyName("locationName")]
        public required string LocationName { get; set; }

        [JsonPropertyName("latitude")]
        public required double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public required double Longitude { get; set; }
    }
}
