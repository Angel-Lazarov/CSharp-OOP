﻿namespace SoftUniDI_Framework.Attributes;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field)]
public class Named : Attribute
{
    public Named(string name)
    {
        this.Name = name;
    }
    public string Name { get; }
}
