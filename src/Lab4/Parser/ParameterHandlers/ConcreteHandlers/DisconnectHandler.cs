using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class DisconnectHandler : ParameterHandlerBase
{
    public override ICommandModifier? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "disconnect")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        var command = new DisconnectCommand();

        return new DisconnectModifier(command);
    }
}