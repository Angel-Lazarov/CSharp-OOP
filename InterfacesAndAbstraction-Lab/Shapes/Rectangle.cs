namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            DrowLine(this.width, '*', '*');
            for (int i = 1; i < this.height - 1; ++i) 
            {
                DrowLine(this.width, '*', ' ');
            }
            DrowLine(this.width, '*', '*');
        }

        private void DrowLine(int width, char end, char mid) 
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; ++i)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}