using Telephony.Core;
using Telephony.Core.Interfaces;
using Telephony.IO;
namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //FileWriter writer = new ();
            ConsoleWriter writer = new ();
            ConsoleReader reader = new ();

            IEngine engine = new Engine(writer, reader);

            engine.Run();
        }
    }
}
