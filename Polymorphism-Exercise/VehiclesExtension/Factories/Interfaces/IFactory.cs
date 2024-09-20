using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Factories.Interfaces;

public interface IFactory
{
    IVehicle Create(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity);
}
