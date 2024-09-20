public class ConsoleLogger : ILogger
{
    public ConsoleLogger()
    {
        Console.WriteLine("Console logger created!");
    }
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{DateTime.Now} : {message}");
        Console.ForegroundColor= ConsoleColor.White;
    }
}
