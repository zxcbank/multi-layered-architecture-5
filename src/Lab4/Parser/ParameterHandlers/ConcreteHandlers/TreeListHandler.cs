using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class TreeListHandler : ParameterHandlerBase
{
    public override ICommandModifier? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "tree")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        TreeListCommand? command = request.Current switch
        {
            "goto" => new TreeListCommand(),
            _ => null,
        };

        if (command is null)
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        return new TreeListModifier(command);
    }
}