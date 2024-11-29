using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;

public interface IExternalHandler
{
    IExternalHandler AddNext(IExternalHandler handler);

    ICommand? Handle(IEnumerator<string> request);
}