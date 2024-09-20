namespace DI_WorkshopIOC.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{DateTime.Now} : {message}");
        Console.ForegroundColor= ConsoleColor.White;
    }
}
