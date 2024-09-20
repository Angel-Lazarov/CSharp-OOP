﻿namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);

            Citizen citizen = new(name, age, id, birthdate);
            Console.WriteLine(citizen.Name);
            Console.WriteLine(citizen.Age);
            Console.WriteLine(citizen.Id);
            Console.WriteLine(citizen.Birthdate);
        }
    }
}
