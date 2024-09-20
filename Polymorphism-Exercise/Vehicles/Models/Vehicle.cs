using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increase;

        protected Vehicle(double fuel, double consumption, double increase)
        {
            Fuel = fuel;
            Consumption = consumption;
            this.increase = increase;
        }

        public double Fuel { get; private set; }

        public double Consumption { get; private set; }

        public string Drive(double distance)
        {
            double finalConsumption = Consumption + increase;

            if (Fuel < distance * finalConsumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            Fuel -= distance * finalConsumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            Fuel += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Fuel:f2}";
        }
    }
}
