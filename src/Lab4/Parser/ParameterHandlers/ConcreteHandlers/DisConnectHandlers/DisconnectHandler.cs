using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.DisConnectHandlers;

public class DisconnectHandler : ExternalHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        return request.Current is not "disconnect" ? Next?.Handle(request) : new Disconnect();
    }
}