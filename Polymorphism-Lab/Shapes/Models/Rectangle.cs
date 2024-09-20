using System.Runtime.InteropServices;

namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height 
        { 
            get => height; 
            private set => height = value;
        }
        public double Width
        { 
            get => width; 
            private set => width = value; 
        }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return Width * 2 + Height * 2;
        }
    }
}
