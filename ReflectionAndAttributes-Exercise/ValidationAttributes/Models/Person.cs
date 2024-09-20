using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models;

public class Person
{
    private const int MinAge = 12;
    private const int MaxAge = 90;

    private string fullName;
    private int age;

    public Person(string fullName, int age)
    {
        FullName = fullName;
        Age = age;
    }

    [MyRequired]
    public string FullName
    {
        get { return fullName; }
        private set { fullName = value; }
    }

    [MyRange(MinAge, MaxAge)]
    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

}
