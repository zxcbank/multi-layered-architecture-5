using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.FileHandlers;

public class FileCopyHandler : ParameterHandlerBase
{
    public override IBuilder? Handle(IEnumerator<string> request, IBuilder? builder)
    {
        if (request.MoveNext() is false)
            return null;

        string source = request.Current;

        if (request.MoveNext() is false)
            return null;

        string destination = request.Current;

        builder ??= new FileCopyBuilder();

        builder.AddSource(source);
        builder.AddDestination(destination);
        return Next?.Handle(request, builder);
    }
}