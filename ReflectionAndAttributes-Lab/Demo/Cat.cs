namespace Demo;

public class Cat
{
    private int age;
    private string name;
    private double cici;

    public Cat(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    void SayHi()
    {
        Console.WriteLine("Hello form cat!");
    }

}
