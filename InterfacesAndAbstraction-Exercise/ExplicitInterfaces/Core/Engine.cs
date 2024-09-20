using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.Models.Interfaces;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string input = string.Empty;

            List<Citizen> persons = new List<Citizen>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);

                persons.Add(citizen);
            }

            foreach (Citizen person in persons)
            {
                //  Console.WriteLine(((IPerson)person).GetName());
                //  Console.WriteLine(((IResident)person).GetName());
                Console.WriteLine((person as IPerson).GetName());
                Console.WriteLine((person as IResident).GetName());
            }
        }
    }
}
