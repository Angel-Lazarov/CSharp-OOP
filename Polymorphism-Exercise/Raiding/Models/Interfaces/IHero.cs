﻿namespace Raiding.Models.Interfaces
{
    public interface IHero
    {
        string Name { get; }  
        int Power { get; }

        abstract string CastAbility();
    }
}
