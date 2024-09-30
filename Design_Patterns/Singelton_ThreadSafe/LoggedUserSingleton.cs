namespace Singelton_ThreadSafe;

internal class LoggedUserSingleton
{
    private static LoggedUserSingleton instance;
    private static Object lockObject = new Object();
    private int counter;
    private LoggedUserSingleton()
    {
        Console.WriteLine(counter++);
        Console.WriteLine("New user created!");
    }

    public string UserName { get; set; }

    public static LoggedUserSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new LoggedUserSingleton();
                    }

                }
            }
            return instance;
        }
    }

}
