namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        const double IncreasedConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption, IncreasedConsumption)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);
        }
    }
}
