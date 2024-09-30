using CommandPattern.Commands;

namespace CommandPattern;

class Calculator
{
    private List<Command> commands;

    public Calculator()
    {
        commands = new List<Command>();
    }

    public decimal CurrentValue { get; set; }

    public void Calculate(char operatorType, decimal operand)
    {
        Command command = null;

        switch (operatorType)
        {
            case '+':
                command = new PlusCommand(operand);
                break;
            case '-':
                command = new MinusCommand(operand);
                break;
            case '*':
                command = new MultiplyCommand(operand);
                break;
            case '/':
                command = new DivideCommand(operand);
                break;

        }

        commands.Add(command);
        CurrentValue = command.Execute(CurrentValue);
    }

    public void Undo(int levels)
    {
        for (int i = 0; i < levels; i++)
        {
            Command lastCommand = commands[commands.Count - 1];
            commands.RemoveAt(commands.Count - 1);
            CurrentValue = lastCommand.UnExecute(CurrentValue);
        }
    }

    public override string ToString()
    {
        string result = "0 ";

        foreach (Command command in commands)
        {
            result += $"{command.Operator} {command.Value} ";
        }

        result += $"= {CurrentValue}";

        return result;
    }

}
