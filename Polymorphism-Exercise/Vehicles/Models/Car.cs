namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        const double Increase = 0.9;
        public Car(double fuel, double consumption) : base(fuel, consumption, Increase)
        {
            
        }

    }
}
