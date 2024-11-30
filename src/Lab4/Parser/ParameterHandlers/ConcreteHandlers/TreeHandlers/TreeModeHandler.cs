using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.TreeHandlers;

public class TreeModeHandler : ParameterHandlerBase
{
    public override IBuilder? Handle(IEnumerator<string> request, IBuilder? builder)
    {
        if (request.Current != "-m")
            return Next?.Handle(request, builder);

        if (request.MoveNext() is false)
            return null;

        string flag = request.Current;

        if (builder is null)
            return null;

        builder.AddFLag("-m", flag);

        return Next?.Handle(request, builder);
    }
}