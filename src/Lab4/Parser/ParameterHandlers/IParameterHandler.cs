using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;

public interface IParameterHandler
{
    IParameterHandler AddNext(IParameterHandler handler);

    ICommand? Handle(IEnumerator<string> request);
}