using Raiding.Models.Interfaces;

namespace Raiding.Models
{
    public class BaseHero : IBaseHero
    {
        public BaseHero(string name, string type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }

        public string Name { get; private set; }
        public string Type  { get; private set; }

        public int Power { get; private set; }

        public string CastAbility()
        {
            throw new NotImplementedException();
        }
    }
}
