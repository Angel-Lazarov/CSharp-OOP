using CommandPattern;

Calculator calculator = new();
Console.ForegroundColor = ConsoleColor.Blue;
//Console.BackgroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("0");

while (true)
{
    string[] input = Console.ReadLine().Split();
    decimal value = decimal.Parse(input[1]);

    if (input[0][0] == 'u')
    {
        calculator.Undo((int)value);
    }
    else
    {
        calculator.Calculate(input[0][0], decimal.Parse(input[1]));
    }

    Console.Clear();
    Console.WriteLine(calculator);
}