using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.TreeHandlers;

public class TreeHandler : ExternalHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "tree")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        IInternalHandler? handler;
        IBuilder? builder;

        switch (request.Current)
        {
            case "goto":
                handler = new TreeGotoHandler();
                builder = new TreeGotoBuilder();
                break;
            case "list":
                handler = new TreeListHandler();
                builder = new TreeListBuilder();
                break;
            default:
                handler = null;
                builder = null;
                break;
        }

        return (builder is not null) ? handler?.Handle(request, builder)?.Build() : null;
    }
}