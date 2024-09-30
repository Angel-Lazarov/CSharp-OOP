using FoodShortage.Core;
using FoodShortage.Core.Interfaces;

namespace FoodShortage
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engin = new Engine();
            engin.Run();

         
        }
    }
}
