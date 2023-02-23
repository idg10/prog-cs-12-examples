using System.Reflection;
using System.Runtime.Loader;

namespace HostApp;

public class PlugInLoadContext(
    string pluginPath,
    ICollection<string> plugInApiAssemblyNames) : AssemblyLoadContext
{
    private readonly AssemblyDependencyResolver _resolver = new(pluginPath);
    private readonly ICollection<string> _plugInApiAssemblyNames =
        plugInApiAssemblyNames;

    protected override Assembly Load(AssemblyName assemblyName)
    {
        if (!_plugInApiAssemblyNames.Contains(assemblyName.Name!))
        {
            string? assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }
        }

        return AssemblyLoadContext.Default.LoadFromAssemblyName(
            assemblyName);
    }
}