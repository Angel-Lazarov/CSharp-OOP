namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList() { "t", "r", "e"};
            Console.WriteLine(randomList.RandomString());
        }
    }
}
