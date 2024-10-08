﻿using Vehicles.Factories.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories;

public class Factory : IFactory
{
    public IVehicle Create(string type, double fuelQuantity, double fuelConsumption)
    {
        switch (type)
        {
            case "Car":
                return new Car(fuelQuantity, fuelConsumption);

            case "Truck":
                return new Truck(fuelQuantity, fuelConsumption);

            default:
                throw new ArgumentException("Wrong type");
        }
    }
}
