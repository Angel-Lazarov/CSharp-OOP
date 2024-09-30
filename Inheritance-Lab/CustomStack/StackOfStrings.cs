
namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() 
        {
            return this.Any();
            //return this.Count == 0;
        }

        public void AddRange(IEnumerable<string> elements) 
        {
            foreach (var element in elements)
            {
                this.Push(element);
            }
        }
    }
}
