﻿namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string namen, int agen)
        {
            Name = namen;
            Age = agen;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public virtual int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }

    }
}
