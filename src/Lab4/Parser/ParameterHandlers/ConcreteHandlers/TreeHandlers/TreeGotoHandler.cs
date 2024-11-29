using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.TreeHandlers;

public class TreeGotoHandler : InternalHandlerBase
{
    private readonly TreeModeHandler _handler = new TreeModeHandler();

    public override IBuilder? Handle(IEnumerator<string> request, IBuilder builder)
    {
        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        builder.AddPath(path);

        return _handler.Handle(request, builder);
    }
}