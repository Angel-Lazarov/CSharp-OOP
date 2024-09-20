using DI_WorkshopIOC.Renderers;

namespace DI_WorkshopIOC
{
    abstract class Shape
    {
        protected IRenderer renderer;

        public Shape(IRenderer renderer, Position position)
        {
            Position = position;
            this.renderer = renderer;
        }

        public Position Position { get; set; }

        public abstract void Draw();
    }
}