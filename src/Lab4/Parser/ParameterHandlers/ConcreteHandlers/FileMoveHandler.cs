using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class FileMoveHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "file")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "move")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string source = request.Current;

        if (request.MoveNext() is false)
            return null;

        string destination = request.Current;

        FileMoveCommand command = new FileMoveCommand().AddSource(source).AddDestination(destination);

        return command;
    }
}