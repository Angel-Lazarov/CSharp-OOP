using BorderControl.Core.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interface;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            List<IIdentifiable> output = new List<IIdentifiable>();

            string input = string.Empty;

            while ((input = reader.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IIdentifiable unit = null;

                if (tokens.Length < 3)
                {
                    unit = new Robot(tokens[0], tokens[1]);
                }
                else
                {
                    unit = new Citizen(tokens[0], tokens[1], tokens[2]);

                }

                output.Add(unit);
            }

            string magic = reader.ReadLine();

            foreach (IIdentifiable unit in output)
            {
                if (unit.CheckUnit(magic))
                {
                    writer.WriteLine(unit.Id);
                }
            }
        }
    }
}
