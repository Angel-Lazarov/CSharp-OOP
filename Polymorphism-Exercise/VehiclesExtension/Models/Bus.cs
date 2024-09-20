namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double Increase = 1.4;
        public Bus(double fuel, double consumption, double tankCapacity) 
            : base(fuel, consumption, tankCapacity, Increase) { }
    }
}
