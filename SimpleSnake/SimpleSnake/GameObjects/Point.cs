using System;

namespace SimpleSnake.GameObjects;

public class Point
{

    public Point(int leftX, int topY)
    {
        LeftX = leftX;
        TopY = topY;
    }

    public int LeftX { get; set; }
    public int TopY { get; set; }

    public void Draw(char symbol)
    {
        Console.SetCursorPosition(LeftX, TopY);
        Console.Write(symbol);
    }
    public void Draw(int X, int Y, char symbol)
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(symbol);
    }

}
