using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models;

public abstract class Vehicle : IVehicle
{
    private double increase;
    private double initialFuel;

    protected Vehicle(double initialFuel, double consumption, double tankCapacity, double increase)
    {
        TankCapacity = tankCapacity;
        InitialFuel = initialFuel;
        Consumption = consumption;
        this.increase = increase;
    }

    public double InitialFuel
    {
        get => initialFuel;
        private set
        {
            if (value > TankCapacity)
            {
                value = 0;
            }

            initialFuel = value;
        }
    }

    public double Consumption { get; private set; }

    public double TankCapacity { get; private set; }

    public string Drive(double distance, bool isIncreased)
    {
        double finalConsumption = 0;
        if (isIncreased)
        {
            finalConsumption = Consumption + increase;
        }
        else 
        {
            finalConsumption = Consumption;
        }

        if (InitialFuel < distance * finalConsumption)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }

        InitialFuel -= distance * finalConsumption;
        return $"{this.GetType().Name} travelled {distance} km";
    }


    public virtual void Refuel(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (InitialFuel + amount > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
        }

        InitialFuel += amount;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {InitialFuel:f2}";
    }
}