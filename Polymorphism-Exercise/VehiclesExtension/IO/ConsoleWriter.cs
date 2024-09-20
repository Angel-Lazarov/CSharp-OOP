using VehiclesExtension.IO.Interfaces;

namespace VehiclesExtension.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
