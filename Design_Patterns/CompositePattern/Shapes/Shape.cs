﻿namespace CompositePattern.Shapes;

public class Shape
{
    private List<Shape> children;

    public Shape(Position position)
    {
        Position = position;
        children = new List<Shape>();
        ConsoleColor = ConsoleColor.White;
    }

    public Position Position { get; set; }

    public ConsoleColor ConsoleColor { get; set; }

    public virtual void Draw()
    {
        Console.ForegroundColor = ConsoleColor;
        foreach (var child in children)
        {
            child.Draw();
        }
    }

    public virtual void Color(ConsoleColor color)
    {
        this.ConsoleColor = color;
        foreach (var child in children)
        {
            child.Color(color);
        }
    }

    public virtual void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                Position.Top--;
                break;
            case Direction.down:
                Position.Top++;
                break;
            case Direction.left:
                Position.Left--;
                break;
            case Direction.right:
                Position.Left++;
                break;
        }

        foreach (var child in children)
        {
            child.Move(direction);
        }
    }

    public void AddChild(Shape shape)
    {
        children.Add(shape);
    }

    protected void SetCursorPosition(int leftOffset = 0, int rightOffset = 0)
    {
        Console.SetCursorPosition(Position.Left + leftOffset, Position.Top + rightOffset);
    }

}
