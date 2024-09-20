
namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString() 
        {
            Random random = new Random();
            int index = random.Next(0, Count);

            string removed = this[index];
            Remove(removed);
            return removed;
        }
    }
}
