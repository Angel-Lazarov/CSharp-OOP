using PizzaCalories.Models;

namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string[] doughInfo = Console.ReadLine().Split();

                Dough dough = new(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                Pizza pizza = new(pizzaInfo[1], dough);


                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = input.Split();

                    Topping topping = new(toppingInfo[1], double.Parse(toppingInfo[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
