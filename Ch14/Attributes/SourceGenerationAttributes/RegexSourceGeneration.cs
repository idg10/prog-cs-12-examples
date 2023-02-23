using System.Text.RegularExpressions;

namespace SourceGenerationAttributes;

public partial class RegexSourceGeneration
{
    [GeneratedRegex(@"[-+]?\b\d+\b")]
    private static partial Regex IsSignedInteger();

    public static bool TextIsSignedInteger(string text)
        => IsSignedInteger().IsMatch(text);
}
