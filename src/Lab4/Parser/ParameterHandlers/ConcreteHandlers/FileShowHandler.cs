using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class FileShowHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "file")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "show")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "-m")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string mode = request.Current;

        FileShowCommand command = new FileShowCommand().AddPath(path).AddMode(mode);

        return command;
    }
}