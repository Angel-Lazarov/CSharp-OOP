namespace VehiclesExtension.Models.Interfaces
{
    public interface IVehicle
    {
        public double InitialFuel { get; }

        public double Consumption { get; }

        public double TankCapacity { get; }

        string Drive(double distance, bool isIncreased = true);

        void Refuel(double amount);
    }
}
