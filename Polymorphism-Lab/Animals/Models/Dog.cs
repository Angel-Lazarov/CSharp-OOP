namespace Animals.Models
{
    public class Dog : Animal
    {
        public Dog(string favouriteFood, string name) : base(favouriteFood, name)
        {
        }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + " DJAAF";
        }
    }
}
