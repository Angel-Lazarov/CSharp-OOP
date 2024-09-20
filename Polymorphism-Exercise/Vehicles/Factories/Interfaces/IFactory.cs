using Vehicles.Models.Interfaces;

namespace Vehicles.Factories.Interfaces;

public interface IFactory
{
    IVehicle Create(string vehicleType, double fuelQuantity, double fuelConsumption);
}
