using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class TreeListHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "tree")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "list")
            return Next?.Handle(request);

        var command = new TreeListCommand();

        if (request.MoveNext() is false)
            return command.AddDepth(1);

        if (request.Current is not "-d")
            return null;

        if (request.MoveNext() is false)
            return null;

        string depth = request.Current;

        command.AddDepth(int.Parse(depth));

        return command;
    }
}