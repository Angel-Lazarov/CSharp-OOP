using Vehicles.Core.Interfaces;
using Vehicles.Models.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Factories.Interfaces;

namespace Vehicles.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IFactory factory;
    private readonly ICollection<IVehicle> vehicles;

    public Engine(IReader reader, IWriter writer, IFactory factory)
    {
        this.reader = reader;
        this.writer = writer;
        this.factory = factory;
        this.vehicles = new List<IVehicle>();

    }

    public void Run()
    {

        vehicles.Add(CreateVehicle());
        vehicles.Add(CreateVehicle());

        int.TryParse(reader.ReadLine(), out int count);

        for (int i = 0; i < count; i++)
        {
            try
            {
                ProcessCommand();
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
            catch (Exception)
            { throw; }
        }

        foreach (var vehicle in vehicles)
        {
            writer.WriteLine(vehicle.ToString());
        }
    }

    private IVehicle CreateVehicle()
    {
        string[] info = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        return factory.Create(info[0], double.Parse(info[1]), double.Parse(info[2]));
    }

    void ProcessCommand()
    {
        string[] commnandInfo = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string command = commnandInfo[0];
        string type = commnandInfo[1];
        double amount = double.Parse(commnandInfo[2]);

        IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);


        if (vehicle == null)
        {
            throw new ArgumentException("Invalid type vehicle!");
        }

        if (command == "Drive")
        {
            writer.WriteLine(vehicle.Drive(amount));
        }
        else if (command == "Refuel")
        {
            vehicle.Refuel(amount);
        }
    }



}
