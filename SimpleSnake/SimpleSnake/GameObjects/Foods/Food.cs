namespace SimpleSnake.GameObjects.Foods;

using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Food : Point
{
    private Random random;
    private char foodSymbol;
    private Wall wall;

    protected Food(Wall wall, char foodSymbol, int foodPoints) : base(wall.LeftX, wall.TopY)
    {
        random = new();
        this.wall = wall;   
        this.foodSymbol = foodSymbol;
        FoodPoints = foodPoints;
    }

    public int FoodPoints { get; private set; }

    public void SetRandomPosition(Queue<Point> snakeElements)
    {
        LeftX = random.Next(2, wall.LeftX - 2);
        TopY = random.Next(2, wall.TopY - 2);

        bool isSnakeElement = snakeElements.Any(se => se.LeftX == this.LeftX && se.TopY == this.TopY);

        while (isSnakeElement)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            isSnakeElement = snakeElements.Any(se => se.LeftX == this.LeftX && se.TopY == this.TopY);
        }

        Console.ForegroundColor = ConsoleColor.DarkRed;
        this.Draw(foodSymbol);
        Console.ForegroundColor = ConsoleColor.Black;
    }

    public bool IsFoodPoint(Point snakeHead)
    {
        return snakeHead.LeftX == this.LeftX && snakeHead.TopY == this.TopY;
    }

}
