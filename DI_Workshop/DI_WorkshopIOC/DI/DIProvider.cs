using DI_WorkshopIOC.Loggers;
using DI_WorkshopIOC.Renderers;
using Microsoft.Extensions.DependencyInjection;

namespace DI_WorkshopIOC.DI;

public class DIProvider
{
    public static IServiceProvider GetServiceProvider() 
    {
        ServiceCollection collection = new ServiceCollection();

        collection.AddSingleton<IRenderer, ConsoleRenderer>();
        collection.AddSingleton<Canvas, Canvas>();
        collection.AddSingleton<ILogger, FileLogger>();

        ServiceProvider provider = collection.BuildServiceProvider();
        return provider;
    }
}
