using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double IncreasedConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double increased)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.IncreasedConsumption = increased;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }


        public string Drive(double distance)
        {
            double consumption = FuelConsumption + IncreasedConsumption;

            if (FuelQuantity > distance * consumption)
            {
                FuelQuantity -= distance * consumption;

                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double fuelToAdd)
        {
            if (fuelToAdd <= 0)
            {
                throw new Exception($"Fuel must be a positive number");
            }

            FuelQuantity += fuelToAdd;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
