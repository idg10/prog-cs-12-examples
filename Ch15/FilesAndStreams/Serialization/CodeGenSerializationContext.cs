using System.Text.Json.Serialization;

using static Serialization.SystemTextJson;

namespace Serialization;

[JsonSerializable(typeof(SimpleData))]
internal partial class CodeGenSerializationContext : JsonSerializerContext
{
}