using System;
using System.Collections.Generic;
using System.Linq;
using SimpleSnake.GameObjects.Foods;
using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects;
public class Snake
{
    private const char SnakeSymbol = '\u25CF';
    private const char emptySpace = ' ';
    private const int SnakeStartTopY = 1;
    private const int SnakeStartLenght = 6;

    private readonly Queue<Point> snakeElements;
    private readonly Wall wall;
    private readonly ReflectionHelper reflectionHelper;
    private IList<Food> foods;

    private int nextLeftX;
    private int nextTopY;
    private int foodIndex;

    private Snake()
    {
        this.snakeElements = new Queue<Point>();
        this.foods = new List<Food>();
        this.foodIndex = this.RandomFoodNumber;
        this.reflectionHelper = new ReflectionHelper();
        
        CreateSnake();
    }

    public Snake(Wall wall) : this()
    {
        this.wall = wall;
       
        GetFoods();
    }

    public int FoodEaten { get; set; }
    public int RandomFoodNumber =>
        new Random().Next(0, foods.Count);

    public bool IsMoving(Point direction)
    {
        Point currentSnakeHead = snakeElements.Last();

        GetNextPoint(direction, currentSnakeHead);
        bool isPointOfSnake = snakeElements.Any(se => se.LeftX == nextLeftX && se.TopY == nextTopY);

        if (isPointOfSnake)
        {
            return false;
        }

        Point snakeNewHead = new Point(nextLeftX, nextTopY);

        if (wall.IsPointOfWall(snakeNewHead))
        {
            return false;   
        }

        snakeElements.Enqueue(snakeNewHead);
        snakeNewHead.Draw(SnakeSymbol);

        if (foods[foodIndex].IsFoodPoint(snakeNewHead))
        {
            Eat(direction, currentSnakeHead);
        }

        Point snakeTail = snakeElements.Dequeue();
        snakeTail.Draw(emptySpace);

        return true;
    }

    private void Eat(Point direction, Point currentSnakeHead)
    {
        int foodPoints = foods[foodIndex].FoodPoints;

        for (int i = 0; i < foodPoints; i++)
        {
            snakeElements .Enqueue(new Point(nextLeftX, nextTopY));
            GetNextPoint(direction, currentSnakeHead);
        }

        FoodEaten += foodPoints;

        CreateFood();
    }

    private void CreateFood()
    {
        foodIndex = RandomFoodNumber;
        foods[foodIndex].SetRandomPosition(snakeElements);
    }

    private void CreateSnake()
    {
        for (int topY = SnakeStartTopY; topY < SnakeStartLenght; topY++)
        {
            snakeElements.Enqueue(new Point(2, topY));
        }
    }

    private void GetFoods()
    {
        //foods.Add(new FoodAsterisk(wall));
        //foods.Add(new FoodDollar(wall));
        //foods.Add(new FoodHash(wall));
        this.foods = this.reflectionHelper
            .GenerateFoods(this.wall)
            .ToList();

        this.CreateFood();
    }

    private void GetNextPoint(Point direction, Point snakeHead)
    {
        nextLeftX = direction.LeftX + snakeHead.LeftX;
        nextTopY = direction.TopY + snakeHead.TopY;
    }


}
