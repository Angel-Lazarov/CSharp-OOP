namespace CompositePattern
{
    public class Position
    {
        public Position(int top, int bottom)
        {
            Top = top;
            Left = bottom;
        }

        public int Top { get; set; }
        public int Left { get; set; }
    }
}