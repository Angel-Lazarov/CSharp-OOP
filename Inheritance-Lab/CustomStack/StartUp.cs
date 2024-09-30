namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(new string[] { "sdf", "fg", "45t"});

            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(stack.Count);

        }
    }
}
