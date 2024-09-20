namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(IEnumerable<string> colection)
        {
            foreach (var item in colection)
            {   
                this.Push(item);
            }
        }
    }
}
