namespace Raiding.Models
{
    public class Rogue : Hero
    {
        private const int Power = 80;
        public Rogue(string name, string type) : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";

        }
    }
}
