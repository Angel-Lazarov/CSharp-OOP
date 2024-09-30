using BorderControl.Core;
using BorderControl.Core.Interfaces;
using BorderControl.IO;

namespace BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ConsoleReader reader = new();
            //ConsoleWriter writer = new();
            FileWriter writer = new();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
