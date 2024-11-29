﻿using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.FileHandlers;

public class FileRenameHandler : InternalHandlerBase
{
    public override IBuilder? Handle(IEnumerator<string> request, IBuilder builder)
    {
        if (request.MoveNext() is false)
            return null;

        string source = request.Current;

        if (request.MoveNext() is false)
            return null;

        string name = request.Current;

        builder.AddSource(source);
        builder.AddName(name);
        return builder;
    }
}