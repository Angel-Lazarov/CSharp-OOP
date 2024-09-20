using System.Reflection;



Type catType = typeof(Cat);

FieldInfo[] catFields = catType.GetFields();

foreach (var field in catFields)
{
    Console.WriteLine($"Name of field {field.Name}");
    Console.WriteLine(field.FieldType.Name);
    Console.WriteLine(field.MemberType);
    Console.WriteLine(field.DeclaringType);
}


public class Cat
{
    public string name;
}