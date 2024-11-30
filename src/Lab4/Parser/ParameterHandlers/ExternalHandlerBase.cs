using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;

public abstract class ExternalHandlerBase : IExternalHandler
{
    protected IExternalHandler? Next { get; private set; }

    public IExternalHandler AddNext(IExternalHandler handler)
    {
        if (Next is null)
        {
            Next = handler;
        }
        else
        {
            Next.AddNext(handler);
        }

        return this;
    }

    public abstract ICommand? Handle(IEnumerator<string> request);
}