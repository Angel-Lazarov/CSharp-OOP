using Telephony.IO.Interfaces;

namespace Telephony.IO
{
    public class ConsoleReader : IReader
    {
        //Създава конзолен reader, който чете от конзолата.
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
