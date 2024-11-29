using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.TreeHandlers;

public class TreeDepthHandler : InternalHandlerBase
{
    public override IBuilder? Handle(IEnumerator<string> request, IBuilder builder)
    {
        if (request.Current != "-d")
            return Next?.Handle(request, builder);

        if (request.MoveNext() is false)
            return null;

        string flag = request.Current;

        builder.AddFLag("-d", flag);

        return builder;
    }
}