using DI_WorkshopIOC.DI;
using DI_WorkshopIOC.Renderers;
using Microsoft.Extensions.DependencyInjection;

namespace DI_WorkshopIOC;

public class Canvas
{
    private List<Shape> shapes;
    public Canvas(IRenderer renderer)
    {
        IRenderer newRenderer = DIProvider.GetServiceProvider().GetRequiredService<IRenderer>();

        shapes = new List<Shape>();
        //                                         col, row
        shapes.Add(new Circle(renderer, new Position(0, 0)));
        shapes.Add(new Rectangle(renderer, new Position(8, 0)));
        shapes.Add(new Circle(renderer, new Position(0, 5)));
        shapes.Add(new Rectangle(renderer, new Position(8, 5)));
    }

    public void Draw() 
    {
    foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}
