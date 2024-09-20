public class Company 
{

    private ILogger logger;

    public Company(ILogger logger)
    {
        this.logger = logger;
        Console.WriteLine("Company created!");
    }

    public void RaiseSalary() 
    {
        logger.Log("Salary raised!");
    }
}