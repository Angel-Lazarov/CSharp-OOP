﻿namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Count() < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            private set
            {
                if (value.Count() < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }
            private set
            {
                //if (value < 650)
                //{
                //    throw new ArgumentException("Salary cannot be less than 650 leva!");
                //}
                salary = value;
            }
        }

        //public void IncreaseSalary(decimal percentage)
        //{
        //    if (Age < 30)
        //    {
        //        percentage /= 2;
        //    }
        //    Salary += Salary * percentage / 100;
        //}

        //public override string ToString()
        //{
        //    return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        //}
    }
}
