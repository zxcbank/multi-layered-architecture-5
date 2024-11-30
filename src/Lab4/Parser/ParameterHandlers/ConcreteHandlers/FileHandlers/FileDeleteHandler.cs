using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.FileHandlers;

public class FileDeleteHandler : ParameterHandlerBase
{
    public override IBuilder? Handle(IEnumerator<string> request, IBuilder? builder)
    {
        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        builder ??= new FileDeleteBuilder();
        builder.AddPath(path);

        return Next?.Handle(request, builder);
    }
}