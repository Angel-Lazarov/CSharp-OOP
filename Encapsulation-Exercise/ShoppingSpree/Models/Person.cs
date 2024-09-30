using System.Collections.Concurrent;
using System.Text;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string personName, decimal personMoney)
        {
            Name = personName;
            Money = personMoney;
            products = new();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        //public IReadOnlyCollection<Product> Bag 
        //{
        //	get => bag;
        //}

        public int bagCount => products.Count;
        public string BuyProduct(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }
            products.Add(product);
            Money -= product.Cost;
            return $"{Name} bought {product.Name}";
        }


        public override string ToString()
        {
            if (products.Any())
            {
                return $"{name} - {string.Join(", ", products.Select(p => p.Name))}";
            }
            else
            {
                return $"{name} - Nothing bought";
            }
        }

        //public override string ToString()
        //{
        //    IEnumerable<string> productString = products.Select(p => p.Name);

        //    string productsString = products.Any()
        //        ? string.Join(", ", productString)
        //        : "Nothing bought";

        //    return $"{name} - {productsString}";

        //    string productsString = products.Any()
        //        ? string.Join(", ", products.Select(p => p.Name))
        //        : "Nothing bought";
        //    return $"{name} - {productsString}";

        //}
    }
}
