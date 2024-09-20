using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interface;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> output = new();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IBirthable unit = null;

                if (tokens[0] == "Citizen")
                {
                    unit = new Citizen(tokens[1], tokens[2], tokens[3], tokens[4]);
                }
                else if (tokens[0] == "Pet")
                {
                    unit = new Pet(tokens[1], tokens[2]);
                }
                if (unit is not null)
                {
                    output.Add(unit);
                }

            }

            string magic = Console.ReadLine();

            foreach (IBirthable unit in output)
            {
                if (unit.BirthDate.EndsWith(magic))
                {
                    Console.WriteLine(unit.BirthDate);
                }
            }
        }
    }
}
