
using SoftUniDI_Framework.Attributes;

namespace SoftUniDI_Framework.Modules;

public abstract class AbstractModule : IModule
{
    private IDictionary<Type, Dictionary<string, Type>> implementations;
    private IDictionary<Type, object> instances;

    protected AbstractModule()
    {
        this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
        this.instances = instances = new Dictionary<Type, object>();
    }

    public abstract void Configure();

    protected void CreateMapping<TInter, TImpl>()
    {
        if (!this.implementations.ContainsKey(typeof(TInter)))
        {
            this.implementations[typeof(TInter)] = new Dictionary<string, Type>();
        }
        this.implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
    }

    public object GetInstance(Type implementation)
    {
        this.instances.TryGetValue(implementation, out object value);
        return value;
    }

    public Type GetMapping(Type currentInterface, object attribute)
    {
        IDictionary<string, Type> currentImplementation = this.implementations[currentInterface];

        Type type = null;

        if (attribute is Inject)
        {
            if (currentImplementation.Count == 1)
            {
                type = currentImplementation.Values.First();
            }
            else
            {
                throw new ArgumentException("No available mapping for class: " + currentInterface.FullName);
            }
        }
        else if (attribute is Named)
        {
            Named named = attribute as Named;
            string dependencyName = named.Name;
            type = currentImplementation[dependencyName];
        }
        return type;
    }

    public void SetInstance(Type implementation, object instance)
    {
        if(!this.instances.ContainsKey(implementation)) 
        {
            this.instances.Add(implementation, instance);
        }
    }
}
