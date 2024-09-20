using Raiding.Models.Interfaces;

namespace Raiding.Factories.Interfaces
{
    public interface IFactory
    {
        IHero Create(string name, string type);
    }
}
