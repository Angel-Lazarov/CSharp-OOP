using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string animaltype = string.Empty;

            while((animaltype = Console.ReadLine()) != "Beast!") 
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = command[0];
                int age = int.Parse(command[1]);
                string gender = command[2];

                try
                {
                    if (animaltype == "Cat")
                    {
                        Cat cat = new(name, age, gender);
                        Console.WriteLine(animaltype);
                        Console.WriteLine(cat);
                    }
                    else if (gender == "Tomcat")
                    {
                        Tomcat tomcat = new(name, age);
                        Console.WriteLine(animaltype);
                        Console.WriteLine(tomcat);
                    }
                    else if (gender == "Kitten")
                    {
                        Kitten kitten = new(name, age);
                        Console.WriteLine(animaltype);
                        Console.WriteLine(kitten);
                    }

                    else if (animaltype == "Dog")
                    {
                        Dog dog = new(name, age, gender);
                        Console.WriteLine(animaltype);
                        Console.WriteLine(dog);
                    }
                    else
                    {
                        Frog frog = new(name, age, gender);
                        Console.WriteLine(animaltype);
                        Console.WriteLine(frog);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
