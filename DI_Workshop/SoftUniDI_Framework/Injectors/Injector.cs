using SoftUniDI_Framework.Attributes;
using SoftUniDI_Framework.Modules;
using System.Reflection;

namespace SoftUniDI_Framework.Injectors;

public class Injector
{
    private IModule module;

    public Injector(IModule module)
    {
        this.module = module;
    }

    private bool CheckForFieldInjection<TClass>()
    {
        return typeof(TClass)
            .GetFields((BindingFlags)62)
            .Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
    }

    private bool CheckForConstruvtorInjection<TClass>()
    {
        return typeof(TClass).GetConstructors()
            .Any(constructor => constructor.GetCustomAttributes(typeof(Inject), true)
        .Any());
    }

    private TClass CreateConstructorInjection<TClass>()
    {
        Type desireClass = typeof(TClass);

        if (desireClass == null)
        {
            return default(TClass);
        }
        ConstructorInfo[] constructors = desireClass.GetConstructors();

        foreach (ConstructorInfo constructor in constructors)
        {
            if (!CheckForConstruvtorInjection<TClass>())
            {
                continue;
            }

            var inject = (Inject)constructor
                .GetCustomAttributes(typeof(Inject), true)
                .FirstOrDefault();

            var parameterTypes = constructor.GetParameters();
            var constructorParams = new object[parameterTypes.Length];

            var i = 0;

            foreach (var parameterType in parameterTypes)
            {
                var named = parameterType.GetCustomAttribute(typeof(Named));
                Type dependency = null;

                if (named == null)
                {
                    dependency = this.module.GetMapping(parameterType.ParameterType, inject);
                }
                else
                {
                    dependency = this.module.GetMapping(parameterType.ParameterType, named);
                }


                if (parameterType.ParameterType.IsAssignableFrom(dependency))
                {
                    object instance = this.module.GetInstance(dependency);
                    if (instance != null)
                    {
                        constructorParams[i++] = instance;
                    }
                    else
                    {
                        instance = Activator.CreateInstance(dependency);
                        constructorParams[i++] = instance;
                        this.module.SetInstance(parameterType.ParameterType, instance);
                    }
                }
            }
            return (TClass)Activator.CreateInstance(desireClass, constructorParams);
        }
        return default(TClass);
    }

    private TClass CreateFieldsInjection<TClass>()
    {
        var desireClass = typeof(TClass);
        var desireClassInstance = this.module.GetInstance(desireClass);

        if (desireClassInstance != null)
        {
            desireClassInstance = Activator.CreateInstance(desireClass);
            this.module.SetInstance(desireClass, desireClassInstance);
        }

        var fields = desireClass.GetFields((BindingFlags)62);

        foreach (var field in fields)
        {
            if (field.GetCustomAttributes(typeof(Inject), true).Any())
            {
                var injection = (Inject)field.GetCustomAttributes(typeof(Inject), true).FirstOrDefault();
                Type dependency = null;

                var named = field.GetCustomAttribute(typeof(Named), true);
                var type = field.FieldType;

                if (named == null)
                {
                    dependency = this.module.GetMapping(type, injection);
                }
                else
                {
                    dependency = this.module.GetMapping(type, named);
                }

                if (type.IsAssignableFrom(dependency))
                {
                    object instance = this.module.GetInstance(dependency);
                    if (instance == null)
                    {
                        instance = Activator.CreateInstance(dependency);
                        this.module.SetInstance(dependency, instance);
                    }
                    field.SetValue(desireClassInstance, instance);
                }
            }
        }
        return (TClass)desireClassInstance;
    }

    public TClass Inject<TClass>()
    {
        var hasConstructorAttribute = this.CheckForConstruvtorInjection<TClass>();
        var hasFieldAttribute = this.CheckForFieldInjection<TClass>();

        if (hasConstructorAttribute && hasFieldAttribute)
        {
            throw new ArgumentException("There must be only field or constructor annotated with Inject attribute");
        }

        if (hasConstructorAttribute)
        {
            return this.CreateConstructorInjection<TClass>();
        }
        else if (hasFieldAttribute)
        {
            return this.CreateFieldsInjection<TClass>();
        }
        return default(TClass);
    }
}
