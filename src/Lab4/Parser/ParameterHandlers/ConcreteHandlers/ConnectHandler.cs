using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;

public class ConnectHandler : ParameterHandlerBase
{
    public override ICommandModifier? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "connect")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string adress = request.Current;

        var command = new ConnectCommand();

        command.AddPath(adress);

        return new ConnectModifier(command);
    }
}

// connect adress -m yatoro
// connect -m yatoro adress 