﻿using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Modifiers;

public class TreeListModifier(TreeListCommand newcommand) : ICommandModifier
{
    public ACommand Modify(ACommand command)
    {
        command = newcommand;
        return command;
    }
}