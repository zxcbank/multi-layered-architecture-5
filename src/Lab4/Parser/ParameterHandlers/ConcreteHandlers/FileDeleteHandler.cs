using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class FileDeleteHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "file")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "delete")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        FileDeleteCommand command = new FileDeleteCommand().AddPath(path);

        return command;
    }
}