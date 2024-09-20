using DI_WorkshopIOC.Renderers;

namespace DI_WorkshopIOC
{
    internal class Circle : Shape
    {

        public Circle(IRenderer renderer, Position position) : base(renderer, position)
        {
        }

        public override void Draw() 
        {
            renderer.WriteLine("  **  ", Position);
            renderer.WriteLine("*    *", Position);
            renderer.WriteLine("*    *", Position);
            renderer.WriteLine("  **  ", Position);
        }
    }
}