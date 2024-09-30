namespace Singleton;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Who are you?");
        string name = Console.ReadLine();

        LoggedUserSingleton.Instance.Name = name;
        LoggedUserSingleton loggedUser = LoggedUserSingleton.Instance;

        Console.WriteLine($"{LoggedUserSingleton.Instance.Name} is logged in!");
    }
}
