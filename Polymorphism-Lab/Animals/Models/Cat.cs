namespace Animals.Models
{
    public class Cat : Animal
    {
        public Cat(string favouriteFood, string name) : base(favouriteFood, name)
        {
        }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "MEEOW";
        }
    }
}
