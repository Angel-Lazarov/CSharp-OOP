﻿using FoodShortage.Models.Interface;

namespace FoodShortage.Models
{
    public class Pet : IBirthable, INameable
    {

        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public string BirthDate { get; private set; }
    }
}
