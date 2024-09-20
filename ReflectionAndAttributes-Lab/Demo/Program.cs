using System.Reflection;

namespace Demo;

internal class Program
{
    static void Main(string[] args)
    {

        Type catType = typeof(Cat);
        //var obj = Activator.CreateInstance(catType);
        //Frog frog = (Frog)Activator.CreateInstance(frogType);
        //Cat cat = new Cat("d", 4);

        //FieldInfo[] catFields = catType.GetFields(BindingFlags.NonPublic | BindingFlags.Static);


        //foreach (var field in catFields)
        //{
        //    Console.WriteLine($"Name of field {field.Name}");
        //    Console.WriteLine(field.FieldType.Name);
        //    Console.WriteLine(field.IsPrivate);
        //    Console.WriteLine(field.MemberType);
        //    Console.WriteLine(field.DeclaringType);
        //}

        // shutdown /s /t 138600

        //var catProperties = catType.GetProperties();
        //foreach (var property in catProperties)
        //{
        //    Console.WriteLine($"Name of property {property.Name}");
        //    Console.WriteLine(property.PropertyType.Name);
        //    Console.WriteLine(property.MemberType);
        //    Console.WriteLine(property.DeclaringType);
        //}

        Type frogType = typeof(Frog);
        FieldInfo[] frogFields = frogType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var field in frogFields)
        {
            Console.WriteLine($"Name of field {field.Name}");
            Console.WriteLine(field.FieldType.Name);
            Console.WriteLine($"Is Private -> {field.IsPrivate}");
            Console.WriteLine(field.MemberType);
            Console.WriteLine(field.DeclaringType);
            Console.WriteLine("-----------------\n--------------");

        }

    }
    public class Frog
    {
        private string name;
        public int age;
    }
}
