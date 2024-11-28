﻿using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class ConnectHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "connect")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string adress = request.Current;

        ConnectCommand command = new ConnectCommand().AddPath(adress);

        return command;
    }
}