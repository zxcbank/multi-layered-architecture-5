namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class TreeHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "tree")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "goto")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        var command = new TreeGotoCommand();

        command.AddPath(path);

        return command;
    }
}