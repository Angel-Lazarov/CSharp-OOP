using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands;

public class PrintCommand : ICommand
{
    public string Execute(string[] args)
        => $"Printing {args[0]}";
}
