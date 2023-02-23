namespace CustomAttributes.Generics;

[AttributeUsage(AttributeTargets.Class)]
public class PluginHelpProviderAttribute<TProvider> : Attribute
    where TProvider : IPluginHelpProvider
{
    public Type ProviderType => typeof(TProvider);
}

// Usage:
[PluginInformation("Reporting", "Endjin Ltd.")]
[PluginHelpProviderAttribute<ReportingPluginHelpProvider>]
public class ReportingPlugin
{
    // ...
}

// Bits required to make the fictional example above work.
public interface IPluginHelpProvider
{
}

public class ReportingPluginHelpProvider : IPluginHelpProvider
{
}