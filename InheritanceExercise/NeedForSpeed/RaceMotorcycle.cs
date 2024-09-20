
using System.Security.Cryptography.X509Certificates;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double defaultFuelConsumption = 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        { }
        public override double FuelConsumption
        {
            get => defaultFuelConsumption;
            set => FuelConsumption = FuelConsumption;
        }
    }
}

