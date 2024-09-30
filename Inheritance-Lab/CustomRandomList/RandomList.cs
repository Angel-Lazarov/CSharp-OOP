
namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public string RandomString() 
        {
            int index = random.Next(0, this.Count);
            string element = this[index];
            //this.RemoveAt(index);
            Remove(this[index]);
            return element;
        }
    }
}
