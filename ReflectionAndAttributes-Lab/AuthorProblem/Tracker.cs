using System.Reflection;

namespace AuthorProblem;

public class Tracker
{
    //public void PrintMethodsByAuthor()
    //{
    //    Type[] types = Assembly.GetExecutingAssembly().GetTypes();

    //    foreach (Type type in types)
    //    {
    //        var methods = type.GetMethods();

    //        foreach (var method in methods)
    //        {
    //            AuthorAttribute[] authorAttribute = type.GetCustomAttributes<AuthorAttribute>().ToArray();

    //            foreach (var attribute in authorAttribute)
    //            {
    //                Console.WriteLine($"{method.Name} is written by {attribute.Name}");

    //            }
    //        }
    //    }
    //}

    public void PrintMethodsByAuthor()
    {
        Type startUp = typeof(StartUp);

        MethodInfo[] methods = startUp.GetMethods((BindingFlags)60);

        foreach (var method in methods)
        {
            AuthorAttribute[] attributes = method.GetCustomAttributes<AuthorAttribute>().ToArray();

            if (attributes.Length > 0)
            {
                foreach (var attr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");

                }
            }

        }
    }
}
