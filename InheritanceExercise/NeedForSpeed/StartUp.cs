using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sport = new(123, 100);
            sport.Drive(4);
            Console.WriteLine(sport.Fuel);
        }
    }
}
