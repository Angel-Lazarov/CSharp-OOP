
namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const int defaultFuelConsimption = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption 
        { 
            get => defaultFuelConsimption;
            set => FuelConsumption = defaultFuelConsimption;
        }
    }
}
