using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;

public interface IInternalHandler
{
    IInternalHandler AddNext(IInternalHandler handler);

    IBuilder? Handle(IEnumerator<string> request, IBuilder builder);
}