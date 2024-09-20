namespace Raiding.Models
{
    public class Warrior : Hero
    {
        private const int Power = 100;
        public Warrior(string name, string type) : base(name, Power)
        {
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
