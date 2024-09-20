namespace Raiding.Models
{
    public class Druid : Hero
    {
        private const int Power = 80;

        public Druid(string name, string type) : base(name,  Power)
        {
        }

        public override string CastAbility()
        {
                return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
