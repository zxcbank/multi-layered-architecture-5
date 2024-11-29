using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.ConnectHandlers;

public class ConnectHandler : ExternalHandlerBase
{
    private readonly ConnectFlagOneHandler handler = new ConnectFlagOneHandler();

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "connect")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string adress = request.Current;

        if (request.MoveNext() is false)
            return null;

        ConnectBuilder cnnctbld = new ConnectBuilder().AddPath(adress);

        return handler.Handle(request, cnnctbld)?.Build();
    }
}