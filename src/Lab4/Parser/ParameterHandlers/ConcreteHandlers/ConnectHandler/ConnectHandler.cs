using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
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

        if (request.MoveNext() is false)
            return null;

        if (request.Current != "-m")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string mode = request.Current;

        Connect command = new Connect().AddPath(adress).AddMode(mode);

        return command;
    }
}