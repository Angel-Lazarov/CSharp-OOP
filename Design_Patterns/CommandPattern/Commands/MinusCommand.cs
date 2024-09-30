namespace CommandPattern.Commands;

public class MinusCommand : Command
{
    public MinusCommand(decimal value) : base(value)
    {
        Operator = '-';

    }

    public override decimal Execute(decimal calculatorValue)
    {
        return calculatorValue - Value;
    }

    public override decimal UnExecute(decimal calculatorValue)
    {
        return calculatorValue + Value;
    }
}
