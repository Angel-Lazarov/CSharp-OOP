namespace Singelton_ThreadSafe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 100; i++)
            {
                new Thread
                    (() =>
                LoggedUserSingleton.Instance.UserName = i.ToString()
                ).Start();

            }


            //Console.Write("Enter username: ");
            //string name = Console.ReadLine();
            //Console.WriteLine("Name will be Changed");

            //LoggedUserSingleton.Instance.UserName = name;

            LoggedUserSingleton loggedUser = LoggedUserSingleton.Instance;
            loggedUser.UserName = "Changed";
            Console.WriteLine($"{loggedUser.UserName} is logged!");


        }
    }
}
