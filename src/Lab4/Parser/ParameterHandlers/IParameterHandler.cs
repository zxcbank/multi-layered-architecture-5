using Itmo.ObjectOrientedProgramming.Lab4.Parser.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;

public interface IParameterHandler
{
    IParameterHandler AddNext(IParameterHandler handler);

    ICommandModifier? Handle(IEnumerator<string> request);
}