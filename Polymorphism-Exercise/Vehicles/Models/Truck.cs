namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        const double Increase = 1.6;

        public Truck(double fuel, double consumption) : base(fuel, consumption, Increase)
        {

        }   


        public override void Refuel(double amount)
        {
            base.Refuel(amount * 0.95);
        }

    }// shutdown /s /t 52200
}
