
using System.Reflection;
using ReflectionPluginSDK;

namespace ReflectionPlugin;

class Program
{
    static void Main(string[] args)
    {
    }

    private static List<IPlugin> _plugins = null;

    static List<IPlugin> ReadExtensions()
    {
        var pluginsList = new List<IPlugin>();
        var files = Directory.GetFiles("extensions", "*.dll");

        foreach (var file in files)
        {
            var assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), file));
            
            var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface).ToArray();

            foreach (var pluginType in pluginTypes)
            {
                var pluginInstance = Activator.CreateInstance(pluginType) as IPlugin;
                pluginsList.Add(pluginInstance);
            }
        }

        return pluginsList;
    }
}

