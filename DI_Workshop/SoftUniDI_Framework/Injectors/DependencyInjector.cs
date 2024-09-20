using SoftUniDI_Framework.Modules;

namespace SoftUniDI_Framework.Injectors;

public class DependencyInjector
{
    public static Injector CreateInjector(IModule module) 
    {
        module.Configure();
        return new Injector(module);
    }
}
