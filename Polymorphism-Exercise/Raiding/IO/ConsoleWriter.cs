﻿using Raiding.IO.Interfaces;

namespace Raiding.IO;

internal class ConsoleWriter : IWriter
{
    public void WriteLine(string value)
    {
        Console.WriteLine(value);
    }
}
