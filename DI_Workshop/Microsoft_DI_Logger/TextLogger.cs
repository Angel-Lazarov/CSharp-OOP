public class TextLogger : ILogger
{
    public void Log(string message)
    {
        using (StreamWriter sw = new StreamWriter("../../../logs.txt", true))
        {
            sw.WriteLine($"{DateTime.Now} : {message}");
        }
    }
}
