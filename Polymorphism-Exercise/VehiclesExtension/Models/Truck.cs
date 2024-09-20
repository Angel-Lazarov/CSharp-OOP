namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        const double Increase = 1.6;

        public Truck(double initialFuel, double consumption, double tankCapacity)
            : base(initialFuel, consumption, tankCapacity, Increase) { }

        public override void Refuel(double amount)
        {
            if (amount + InitialFuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            base.Refuel(amount * 0.95);
        }
    }
}
