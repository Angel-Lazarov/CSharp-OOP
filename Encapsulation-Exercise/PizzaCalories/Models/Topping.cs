namespace PizzaCalories.Models
{
    public class Topping
    {
        private const double CaloriesPerGram = 2;
        private double weigh;
        private string type;

        private Dictionary<string, double> modifiers
            = new Dictionary<string, double>()
            { {"meat", 1.2 }, {"veggies", 0.8 }, {"cheese", 1.1 }, {"sauce", 0.9 } };

        public Topping(string type, double weigh)
        {
            Type = type;
            Weigh = weigh;
        }

        public string Type
        {
            get => type;
            private set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }
        public double Weigh
        {
            get => weigh;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{Type} weight should be in the range [1..50].");
                }
                weigh = value;
            }
        }
        public double Calories
        {
            get
            {
                double modifier = modifiers[Type.ToLower()];
                return CaloriesPerGram * modifier * Weigh;
            }
        }
    }
}
