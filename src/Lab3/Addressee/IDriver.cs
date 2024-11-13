﻿using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public interface IDriver
{
    public void Flush();

    public void SetColor();

    public void SetText(Message message);
}