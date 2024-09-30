namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings = new();

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }
        public Dough Dough { get; set; }

        public double CalculateCalaries
        {
            get
            {
                return Dough.Calories + toppings.Sum(t => t.Calories);
            }
        }
        public void AddTopping(Topping topping)
        {

            // == 10 ??????????????
            if (toppings.Count < 0 || toppings.Count > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }


        public override string ToString()
        {
            return $"{Name} - {CalculateCalaries:f2} Calories.";
        }

    }
}
