namespace MoneyTransactions;
internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, double> accounts = new Dictionary<int, double>();
        //1-45.67,2-3256.09,3-97.34
        string[] accountsInfo = Console.ReadLine().Split(",");

        foreach (var account in accountsInfo)
        {
            string[] currentAcc = account.Split('-');

            if (!accounts.ContainsKey(int.Parse(currentAcc[0])))
            {
                accounts[int.Parse(currentAcc[0])] = double.Parse(currentAcc[1]);
            }
            else
            {
                throw new Exception();
            }
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            try
            {
                string[] commandInfo = input.Split();
                string command = commandInfo[0];
                int accNumber = int.Parse(commandInfo[1]);
                double sum = double.Parse(commandInfo[2]);

                switch (command)
                {
                    case "Deposit":
                        accounts[accNumber] += sum;
                        Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
                        break;
                    case "Withdraw":
                        if (accounts[accNumber] < sum)
                        {
                            throw new InvalidOperationException("Insufficient balance!");
                        }
                        accounts[accNumber] -= sum;
                        Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");

                        break;
                    default:
                        throw new ArgumentException("Invalid command!");

                }
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine("Invalid account!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Enter another command"); 
            } 
        }
    }
}
