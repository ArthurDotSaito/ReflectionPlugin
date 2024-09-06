namespace ReflectionPluginSDK;

public class Plugin : IPlugin
{
    public string Title { get; set; }
    public string Description { get; set; }
    public void DoSomething()
    {
        Title = "Reflection Plugin";
        Description = "This is a plugin using reflection.";
        Console.WriteLine($"{Title} - {Description}");
    }
}