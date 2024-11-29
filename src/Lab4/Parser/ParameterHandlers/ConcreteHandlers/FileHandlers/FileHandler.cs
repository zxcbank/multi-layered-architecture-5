using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.FileHandlers;

public class FileHandler : ExternalHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "file")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        IInternalHandler? handler;
        IBuilder? builder;

        switch (request.Current)
        {
            case "copy":
                handler = new FileCopyHandler();
                builder = new FileCopyBuilder();
                break;
            case "move":
                handler = new FileMoveHandler();
                builder = new FileMoveBuilder();
                break;
            case "delete":
                handler = new FileDeleteHandler();
                builder = new FileDeleteBuilder();
                break;
            case "rename":
                handler = new FileRenameHandler();
                builder = new FileRenameBuilder();
                break;
            case "show":
                handler = new FileShowHandler();
                builder = new FileShowBuilder();
                break;
            default:
                handler = null;
                builder = null;
                break;
        }

        return (builder is not null) ? handler?.Handle(request, builder)?.Build() : null;
    }
}