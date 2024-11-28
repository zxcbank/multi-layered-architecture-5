using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class TreeGotoHandler : ParameterHandlerBase
{
    public override ICommandModifier? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "tree")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        TreeGotoCommand? command = request.Current switch
        {
            "goto" => new TreeGotoCommand(),
            _ => null,
        };

        if (command is null)
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "-d")
            command.AddPath(request.Current);

        return new TreeGotoModifier(command);
    }
}