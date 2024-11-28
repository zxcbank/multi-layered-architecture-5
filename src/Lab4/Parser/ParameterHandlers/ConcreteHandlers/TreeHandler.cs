using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class TreeHandler : ParameterHandlerBase
{
    public override ICommandModifier? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "tree")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        ACommand? command = request.Current switch
        {
            "goto" => new TreeGotoCommand(),
            "list" => new TreeListCommand(),
            _ => null,
        };

        if (command is null)
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "-d")
            ((TreeGotoCommand)command).AddPath(request.Current);

        return new ColorTextModifier(command.Value);
    }
}