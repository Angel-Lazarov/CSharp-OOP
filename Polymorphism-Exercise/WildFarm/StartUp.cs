using WildFarm.Core;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;
using WildFarm.IO;
using WildFarm.IO.Interfaces;

namespace WildFarm;
internal class StartUp
{
    static void Main(string[] args)
    {

        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IAnimalFactory animalFactory = new AnimalFactory();
        IFoodFactory foodFactory = new FoodFactory();

        IEngine engine = new Engine(writer, reader, animalFactory, foodFactory);
        engine.Run();
    }
}
