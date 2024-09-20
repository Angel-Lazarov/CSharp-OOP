using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

namespace Raiding.Core;

public class Engine : IEngine
{
    private readonly ICollection<IHero> heroes;
    private readonly IWriter writer;
    private readonly IReader reader;
    private readonly IFactory factory;

    public Engine(IWriter writer, IReader reader, IFactory factory)
    {
        this.writer = writer;
        this.reader = reader;
        this.factory = factory;
        heroes = new List<IHero>();
    }

    public void Run()
    {
        int.TryParse(reader.ReadLine(), out int n);

        while (heroes.Count < n)
        {
            string name = reader.ReadLine();
            string type = reader.ReadLine();

            try
            {
                heroes.Add(factory.Create(name, type));
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        int bossPower = int.Parse(reader.ReadLine());

        foreach (var hero in heroes)
        {
            writer.WriteLine(hero.CastAbility());
        }

        if (heroes.Sum(h => h.Power) >= bossPower)
        {
            writer.WriteLine("Victory!");
        }
        else
        {
            writer.WriteLine("Defeat...");
        }
    }
}
