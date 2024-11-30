using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.TreeHandlers;

public class TreeListHandler : ParameterHandlerBase
{
    public override IBuilder? Handle(IEnumerator<string> request, IBuilder? builder)
    {
        if (request.MoveNext() is false)
            return null;

        builder = new TreeListBuilder();

        return Next?.Handle(request, builder);
    }
}