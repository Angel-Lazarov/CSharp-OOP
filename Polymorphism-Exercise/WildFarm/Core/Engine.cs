using WildFarm.Core.Interfaces;
using WildFarm.Models.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;

namespace WildFarm.Core;

public class Engine : IEngine
{
    private readonly IWriter writer;
    private readonly IReader reader;

    private readonly IAnimalFactory animalFactory;
    private readonly IFoodFactory foodFactory;

    private readonly ICollection<IAnimal> animals;

    public Engine(
        IWriter writer,
        IReader reader,
        IAnimalFactory animalFactory,
        IFoodFactory foodFactory)
    {
        this.writer = writer;
        this.reader = reader;

        this.animalFactory = animalFactory;
        this.foodFactory = foodFactory;

        animals = new List<IAnimal>();
    }


    public void Run()
    {
        string command = string.Empty;
        while ((command = reader.ReadLine()) != "End")
        {
            IAnimal animal = null;

            try
            {
                animal = CreateAnimal(command);

                IFood food = CreateFood();
                writer.WriteLine(animal.ProduceSound());

                animal.Eat(food);
            }
            catch (ArgumentException ex) 
            {
                writer.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
         
            animals.Add(animal);
        }

        foreach (IAnimal animal in animals)
        {
            writer.WriteLine(animal.ToString());
        }
    }

    private IAnimal CreateAnimal(string command)
    {
        string[] animalArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        IAnimal animal = animalFactory.CreateAnimal(animalArgs);

        return animal;
    }

    private IFood CreateFood()
    {
        string[] foodInfo = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string foodType = foodInfo[0];
        int foodQuanity = int.Parse(foodInfo[1]);

        IFood food = foodFactory.CreateFood(foodType, foodQuanity);

        return food;
    }
}

