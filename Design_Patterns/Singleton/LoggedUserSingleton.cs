namespace Singleton;

class LoggedUserSingleton
{
    private static LoggedUserSingleton instance;

    private LoggedUserSingleton()
    {
        Console.WriteLine("Logged user created!");
    }

    public string Name { get; set; }

    public static LoggedUserSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LoggedUserSingleton();
            }
            return instance;
        }
    }
}
