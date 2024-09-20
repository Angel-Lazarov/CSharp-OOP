using DI_WorkshopIOC.Renderers;

namespace DI_WorkshopIOC;

internal class Rectangle : Shape
{
    public Rectangle(IRenderer renderer, Position position) : base(renderer, position)
    { }

    public override void Draw()
    {
        renderer.WriteLine("******", Position);
        renderer.WriteLine("******", Position);
        renderer.WriteLine("******", Position);
        renderer.WriteLine("******", Position);
    }

}
