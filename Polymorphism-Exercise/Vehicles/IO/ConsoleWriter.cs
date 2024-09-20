using Vehicles.IO.Interfaces;

namespace Vehicles.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
