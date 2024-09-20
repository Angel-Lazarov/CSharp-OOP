using BorderControl.Models;
using BorderControl.Models.Interface;

namespace BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ICheckable> output = new List<ICheckable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                ICheckable unit = null;

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

            string magic = Console.ReadLine();

            foreach (ICheckable unit in output) 
            {
                if (unit.CheckUnit(magic))
                {
                    Console.WriteLine(unit.Id);
                }
            
            }
        }
    }
}
