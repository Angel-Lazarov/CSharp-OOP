﻿using System;

namespace Animals
{
    internal class Tomcat : Cat
    {
        private const string Sound = "MEOW";
        private const string TomcatGender = "Male";
        public Tomcat(string name, int age) : base(name, age, TomcatGender)
        {
        }
        public override string ProduceSound() => Sound;
        //{
        //    return Sound;
        //}
    }
}
