namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public virtual double FuelConsumption => defaultFuelConsumption;

        public void Drive(double kilometers) 
        {
            Fuel-= FuelConsumption * kilometers;
        }

    }
}
