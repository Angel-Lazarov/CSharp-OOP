
namespace Telephony.IO.Interfaces
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string line)
        {
            string filePath = "../../../output.txt";

            using StreamWriter sw = new StreamWriter(filePath, true);

            sw.WriteLine(line);
        }
    }
}
