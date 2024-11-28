﻿using Itmo.ObjectOrientedProgramming.Lab4.Parser.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;

public abstract class ParameterHandlerBase : IParameterHandler
{
    protected IParameterHandler? Next { get; private set; }

    public IParameterHandler AddNext(IParameterHandler handler)
    {
        if (Next is null)
        {
            Next = handler;
        }
        else
        {
            Next.AddNext(handler);
        }

        return this;
    }

    public abstract ICommandModifier? Handle(IEnumerator<string> request);
}