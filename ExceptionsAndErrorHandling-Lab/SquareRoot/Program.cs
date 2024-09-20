namespace SquareRoot;

internal class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        ArithmeticException arithmeticException = new ArithmeticException("Invalid number.");

        try
        {
            if (number < 0)
            {
                throw arithmeticException;
            }

            double result = Math.Sqrt(number);
            Console.WriteLine(result);
        }
        catch (ArithmeticException ex)
        {

            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Goodbye.");
        }
    }
}
