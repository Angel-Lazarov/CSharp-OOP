using BorderControl.IO.Interfaces;

namespace BorderControl.IO
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string text)
        {
            string filePath = "../../../output.txt";

            using StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine(text);
        }
    }
}
