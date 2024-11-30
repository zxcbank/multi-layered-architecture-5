using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.FileHandlers;

public class FileHandler : ExternalHandlerBase
{
    private readonly IParameterHandler _handler;

    public FileHandler(IParameterHandler handler)
    {
        _handler = handler;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "file")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        IBuilder? builder = null;

        builder = _handler.Handle(request, builder);

        return _handler.Handle(request, builder)?.Build();
    }
}