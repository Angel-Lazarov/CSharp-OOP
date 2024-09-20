namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        public double Fuel { get; }

        public double Consumption { get; }

        string Drive(double distance);

        void Refuel(double amount);

    }
}
