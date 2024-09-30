namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CofeeMilliliters = 50;
        private const decimal CoffeePrice = 3.5m;

        public Coffee(string name, double caffein) : base(name, CoffeePrice, CofeeMilliliters)
        {
            Caffeine = caffein;
        }

        public double Caffeine { get; set; }

    }
}
