
using System.Reflection;
using ReflectionPluginSDK;

namespace ReflectionPlugin;

class Program
{
    private static List<IPlugin> _plugins = null;
    static void Main(string[] args)
    {
        _plugins = ReadExtensions();
        
        Console.WriteLine($"{_plugins.Count} plugins found.");
        
        foreach (var ext in _plugins)
        {
            Console.WriteLine($"{ext.Title} - {ext.Description}");
        }
        Console.WriteLine("------------------------------------------------");
        foreach (var ext in _plugins)
        {
            ext.DoSomething();
        }
        Console.WriteLine("------------------------------------------------");
        Console.ReadKey();
    }
    static List<IPlugin> ReadExtensions()
    {
        var pluginsList = new List<IPlugin>();
        var files = Directory.GetFiles("extensions", "*.dll");

        foreach (var file in files)
        {
            var assembly = Assembly.LoadFrom(Path.Combine(Directory.GetCurrentDirectory(), file));
            
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

