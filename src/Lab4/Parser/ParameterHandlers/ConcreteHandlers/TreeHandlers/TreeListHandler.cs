using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.TreeHandlers;

public class TreeListHandler : InternalHandlerBase
{
    private readonly TreeDepthHandler _handler = new TreeDepthHandler();

    public override IBuilder? Handle(IEnumerator<string> request, IBuilder builder)
    {
        if (request.MoveNext() is false)
            return null;

        return _handler.Handle(request, builder);
    }
}