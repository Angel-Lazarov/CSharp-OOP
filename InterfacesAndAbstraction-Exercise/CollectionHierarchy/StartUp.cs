using CollectionHierarchy.Core;
using CollectionHierarchy.Core.Interfaces;

namespace CollectionHierarchy
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine2();
            engine.Run();
        }
    }
}
