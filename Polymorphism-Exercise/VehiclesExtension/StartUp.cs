using VehiclesExtension.Core;
using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Factories;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.IO;
using VehiclesExtension.IO.Interfaces;

namespace VehiclesExtension
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IFactory factory = new Factory();

            IEngine engine = new Engine(reader, writer, factory);
            engine.Run();
        }
    }
}
