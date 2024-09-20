namespace DI_WorkshopIOC.Loggers;
public class FileLogger : ILogger
{
    public void Log(string message)
    {
        using (StreamWriter sw = new StreamWriter("../../../logs.txt", true) )
        {
            sw.WriteLine($"{DateTime.Now} : {message}");
        }
    }
}
    