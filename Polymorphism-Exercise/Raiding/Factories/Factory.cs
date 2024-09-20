using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;

namespace Raiding.Factories;

public class Factory : IFactory
{
    public IHero Create(string name, string type)
    {
        switch (type)
        {
            case "Druid":
                return new Druid(name, type);
            case "Paladin":
                return new Paladin(name, type);
            case "Rogue":
                return new Rogue(name, type);
            case "Warrior":
                return new Warrior(name, type);
            default:
                throw new ArgumentException("Invalid hero!");

        }
    }
}
