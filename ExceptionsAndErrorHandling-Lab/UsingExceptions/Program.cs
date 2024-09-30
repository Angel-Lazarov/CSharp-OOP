namespace UsingExceptions;

internal class Program
{
    static void Main(string[] args)
    {
        bool isSucceed = false;

        ArgumentException negativeValue = new ArgumentException("The years must be a positive number!");

        while (!isSucceed)
        {
            try
            {
                Console.Write("Enter your years: ");

                int age = int.Parse(Console.ReadLine());


                if (age <= 0)
                {
                    //throw new ArgumentException();
                    throw negativeValue;
                    //throw new ArgumentException("The years must be a positive number!");
                }

                Console.WriteLine($"After 1 year, you will be {age + 1} years old!");
                isSucceed = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong Input - formatException!");
                Console.WriteLine();
            }
            catch (OverflowException)
            {
                Console.WriteLine("You've entered number bigger than Int!");
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                //throw new Exception("dada", ex);
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            //catch (ArgumentException)
            //{
            //    Console.WriteLine(("The years must be a positive number!"));
            //    Console.WriteLine();
            //}

        }
    }
}
