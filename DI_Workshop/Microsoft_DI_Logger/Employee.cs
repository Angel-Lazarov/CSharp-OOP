public class Employee 
{
    private ILogger logger;

    public Employee(ILogger logger)
    {
        this.logger = logger;
    }

    public void TakeVacation(int days)
    {
        logger.Log($"Took vacation {days} was not enough!!");
    }
}