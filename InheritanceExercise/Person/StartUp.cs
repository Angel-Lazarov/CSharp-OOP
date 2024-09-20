using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            if (age > 15)
            {
                Person person = new Person(name, age);
                Console.WriteLine(person);
            }
            else
            {
                Child child = new Child(name, age);
                Console.WriteLine(child);
            }


            //Person person = new Person("Gosho", 30);
            //Person person2 = new Person("toni", -1);

            //Child child = new Child("Pesho", 10);
            //Child child2 = new Child("Misho", 16);
            //Console.WriteLine(person);
            //Console.WriteLine(person2);
            //Console.WriteLine(child);
            //Console.WriteLine(child2);
        }
    }
}