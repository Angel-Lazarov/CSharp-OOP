namespace CommandPattern.Commands;

class MultiplyCommand : Command
{
    public MultiplyCommand(decimal value) : base(value)
    {
        Operator = '*';
    }

    public override decimal Execute(decimal calculatorValue)
    {
        return calculatorValue * Value;
    }

    public override decimal UnExecute(decimal calculatorValue)
    {
        return calculatorValue / Value;
    }
}
