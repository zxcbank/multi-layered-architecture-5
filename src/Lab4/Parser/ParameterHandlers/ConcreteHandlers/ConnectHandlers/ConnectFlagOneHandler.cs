﻿using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.ConnectHandlers;

public class ConnectFlagOneHandler : InternalHandlerBase
{
    public override IBuilder? Handle(IEnumerator<string> request, IBuilder builder)
    {
        if (request.Current != "-m")
            return Next?.Handle(request, builder);

        if (request.MoveNext() is false)
            return null;

        string flag = request.Current;

        builder.AddFLag("-m", flag);

        return builder;
    }
}