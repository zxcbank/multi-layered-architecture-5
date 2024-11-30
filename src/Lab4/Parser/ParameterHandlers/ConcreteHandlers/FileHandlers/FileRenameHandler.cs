using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.FileHandlers;

public class FileRenameHandler : ParameterHandlerBase
{
    public override IBuilder? Handle(IEnumerator<string> request, IBuilder? builder)
    {
        if (request.MoveNext() is false)
            return null;

        string source = request.Current;

        if (request.MoveNext() is false)
            return null;

        string name = request.Current;

        builder ??= new FileRenameBuilder();

        builder.AddSource(source);
        builder.AddName(name);
        return Next?.Handle(request, builder);
    }
}