using System;
using System.Diagnostics;
using System.Threading;
using SimpleSnake.Core.Interfaces;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core;
public class Engine : IEngine
{
    private const double DefaultSpeeptime = 100;
    private const double EasyDifficultyStep = 0.01;
    private const double MediumDifficultyStep = 0.03;
    private const double HardDifficultyStep = 0.05;

    private readonly Stopwatch timer;

    private Direction direction;
    private Snake snake;
    private readonly Wall wall;
    private double sleepTime;
    private double difficultyStep;
    private Point[] pointsOfDirection;

    private Engine()
    {
        pointsOfDirection = new Point[4];
        sleepTime = DefaultSpeeptime;
        this.timer = new Stopwatch();
    }

    public Engine(Wall wall)
        : this()
    {
        this.wall = wall;
    }

    public void Run()
    {
        this.CreateDirection();
        this.SetDifficultyLevel();

        while (true)
        {
            this.timer.Start();
            ShowScore();

            if (Console.KeyAvailable)
            {
                GetNextDirection();
            }

            bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction]);

            if (!isMoving)
            {
                AskUserForRestart();
            }

            sleepTime -= difficultyStep;
            Thread.Sleep((int)sleepTime);
        }
    }

    private void AskUserForRestart()
    {
        Console.SetCursorPosition(23, 10);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Game over!");
        Console.ForegroundColor = ConsoleColor.Black;


        int leftX = wall.LeftX + 1;
        int topY = 3;

        Console.SetCursorPosition(leftX, topY);
        Console.Write("Would you like to continue? y/n");
        Console.SetCursorPosition(leftX, topY + 1);

        string input = Console.ReadLine();

        if (input == "y")
        {
            Console.Clear();
            StartUp.Main();
        }
        else
        {
            StopGame();
        }
    }

    private void SetDifficultyLevel()
    {
        Console.SetCursorPosition(this.wall.LeftX + 1, 3);
        Console.Write("Choose game difficulty: ");
        Console.SetCursorPosition(this.wall.LeftX + 1, 4);
        Console.Write("#1: Easy");
        Console.SetCursorPosition(this.wall.LeftX + 1, 5);
        Console.Write("#2: Medium");
        Console.SetCursorPosition(this.wall.LeftX + 1, 6);
        Console.Write("#3: Hard");
        Console.SetCursorPosition(this.wall.LeftX + 1, 7);

        string answer = Console.ReadLine();

        if (answer == "1")
        {
            this.difficultyStep = EasyDifficultyStep;
        }
        else if (answer == "2")
        {
            this.difficultyStep = MediumDifficultyStep;
        }
        else if (answer == "3")
        {
            this.difficultyStep = HardDifficultyStep;
        }
        else
        {
            StartUp.Main();
        }

        Console.Clear();
        this.wall.InitializeBorders();
        this.snake = new Snake(wall);
    }

    private void StopGame()
    {
        //Console.SetCursorPosition(20, 10);
        //Console.Write("Game over!");
        Environment.Exit(0);
    }

    private void CreateDirection()
    {
        pointsOfDirection[0] = new Point(1, 0);
        pointsOfDirection[1] = new Point(-1, 0);
        pointsOfDirection[2] = new Point(0, 1);
        pointsOfDirection[3] = new Point(0, -1);
    }

    private void GetNextDirection()
    {
        ConsoleKeyInfo userInput = Console.ReadKey();

        if (userInput.Key == ConsoleKey.LeftArrow)
        {
            if (direction != Direction.Right)
            {
                direction = Direction.Left;
            }
        }
        else if (userInput.Key == ConsoleKey.RightArrow)
        {
            if (direction != Direction.Left)
            {
                direction = Direction.Right;
            }
        }
        else if (userInput.Key == ConsoleKey.UpArrow)
        {
            if (direction != Direction.Down)
            {
                direction = Direction.Up;
            }
        }
        else if (userInput.Key == ConsoleKey.DownArrow)
        {
            if (direction != Direction.Up)
            {
                direction = Direction.Down;
            }
        }

        Console.CursorVisible = false;
    }

    private void ShowScore()
    {
        int leftX = wall.LeftX + 1;
        int topY = 0;

        Console.SetCursorPosition(leftX, topY);
        Console.Write($"Score: {snake.FoodEaten} ");
        Console.SetCursorPosition(leftX, topY + 1);
        Console.Write($"Game Duration: {timer.ElapsedMilliseconds / 1000000:d2}:{timer.ElapsedMilliseconds / 1000:d2}");
        Console.CursorVisible = false;
    }
}
