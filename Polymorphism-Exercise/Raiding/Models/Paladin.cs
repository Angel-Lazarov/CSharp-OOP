namespace Raiding.Models
{
    public class Paladin : Hero
    {
        private const int Power = 100;
        public Paladin(string name, string type) : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
