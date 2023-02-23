using SourceGenerationAttributes;

Console.WriteLine(RegexSourceGeneration.TextIsSignedInteger("123"));
Console.WriteLine(RegexSourceGeneration.TextIsSignedInteger("-456"));
Console.WriteLine(RegexSourceGeneration.TextIsSignedInteger("foo"));
