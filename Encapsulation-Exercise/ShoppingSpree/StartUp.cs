using ShoppingSpree.Models;

namespace ShoppingSpree
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {
                string[] peopleInfo = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < peopleInfo.Length - 1; i += 2)
                {
                    Person person = new(peopleInfo[i], decimal.Parse(peopleInfo[i + 1]));
                    persons.Add(person);
                }

                string[] productInfo = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productInfo.Length - 1; i += 2)
                {
                    Product currentProduct = new(productInfo[i], decimal.Parse(productInfo[i + 1]));

                    if (!products.ContainsKey(productInfo[i]))
                    {
                        products.Add(productInfo[i], currentProduct);
                    }
                    else
                    {
                        products[productInfo[i]] = currentProduct;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }


            string inputOrder = string.Empty;

            while ((inputOrder = Console.ReadLine()) != "END") 
            {
                    string[] orderInfo = inputOrder.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Person currentPerson = persons.FirstOrDefault(p => p.Name == orderInfo[0]);

                    Product currentProduct = products[orderInfo[1]];

                    Console.WriteLine($"{currentPerson.BuyProduct(currentProduct)}");

            }
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
