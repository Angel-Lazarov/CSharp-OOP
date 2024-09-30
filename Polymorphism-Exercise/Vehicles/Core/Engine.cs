using Vehicles.Core.Interfaces;
using Vehicles.Models.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<IVehicle> vehicles;
        private readonly IVehicleFactory vehicleFactory;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>();
        }


        public void Run()
        {
            vehicles.Add(CreateVehicle()); //add Car
            vehicles.Add(CreateVehicle()); // add Truck


            int commandsCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
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
                {
                    throw;
                }
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }

        }

        private IVehicle CreateVehicle() 
        {
            string[] info = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle vehicle = vehicleFactory.Create(info[0], double.Parse(info[1]), double.Parse(info[2]));

            return vehicle;
        }
        private void ProcessCommand()
        {
            string[] commandInfo = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandInfo[0];
            string vehicleType = commandInfo[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);
            if(vehicle == null) 
            {
                throw new ArgumentException("No such type!");
            }


            if (command == "Drive")
            {
                double distance = double.Parse(commandInfo[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double amount = double.Parse(commandInfo[2]);
                vehicle.Refuel(amount);
            }
        }
    }
}
