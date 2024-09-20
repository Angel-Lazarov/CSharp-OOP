using WildFarm.IO.Interfaces;

namespace WildFarm.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }
}
