using FoodShortage.Core.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interface;

namespace FoodShortage.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IBuyer> buyers = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    IBuyer citizen = new Citizen(tokens[0], tokens[1], tokens[2], tokens[3]);

                    buyers.Add(citizen);
                }
                else
                {
                    IBuyer rebel = new Rebel(tokens[0], tokens[1], tokens[2]);
                    buyers.Add(rebel);
                }
            }

            string name = string.Empty;
            while ((name = Console.ReadLine()) != "End")
            {

                foreach (var buyer in buyers)
                {
                    if (buyer.Name == name)
                    {
                        buyer.BuyFood();
                    }
                }

                // buyers.FirstOrDefault(buyer => buyer.Name == name).BuyFood();
            }

            Console.WriteLine(buyers.Sum(buyer => buyer.Food));


        }
    }
}
