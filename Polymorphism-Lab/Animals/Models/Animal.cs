namespace Animals.Models
{
    public abstract class Animal
    {
        protected Animal(string favouriteFood, string name)
        {
            FavouriteFood = favouriteFood;
            Name = name;
        }

        public string FavouriteFood { get; private set; }

		public string Name { get; protected set; }

		public virtual string ExplainSelf() 
		{
			return $"I am {Name} and my fovourite food is {FavouriteFood}";
		}
    }
}
