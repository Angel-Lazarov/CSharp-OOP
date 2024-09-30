namespace CommandPattern.Commands;

class DivideCommand : Command
{
    public DivideCommand(decimal value) : base(value)
    {
        Operator = '/';
    }   

    public override decimal Execute(decimal calculatorValue)
    {
        return calculatorValue / Value;
    }

    public override decimal UnExecute(decimal calculatorValue)
    {
        return calculatorValue * Value;
    }
}
