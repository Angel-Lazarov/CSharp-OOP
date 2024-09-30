using SimpleSnake.Core;
using SimpleSnake.Core.Interfaces;
using SimpleSnake.GameObjects;

namespace SimpleSnake;
using Utilities;

public class StartUp
{
    public static void Main()
    {
        ConsoleWindow.CustomizeConsole();

        Wall wall = new(60,20);
        

        IEngine engine = new Engine(wall);
        engine.Run();
    }
}
