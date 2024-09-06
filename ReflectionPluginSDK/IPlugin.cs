namespace ReflectionPluginSDK;

public interface IPlugin
{
    string Title { get; }
    string Description { get; }
    
    void DoSomething();
}