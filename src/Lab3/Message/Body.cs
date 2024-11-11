﻿namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public class Body
{
    public Body(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }
}