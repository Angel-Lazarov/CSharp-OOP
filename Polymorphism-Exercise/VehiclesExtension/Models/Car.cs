namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double Increase = 0.9;
        public Car(double initialFuel, double consumption, double tankCapacity)
            : base(initialFuel, consumption, tankCapacity, Increase) { }
    }
}
