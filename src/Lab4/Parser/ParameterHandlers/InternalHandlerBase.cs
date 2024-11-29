using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;

public abstract class InternalHandlerBase : IInternalHandler
{
    protected IInternalHandler? Next { get; private set; }

    public IInternalHandler AddNext(IInternalHandler handler)
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

    public abstract IBuilder? Handle(IEnumerator<string> request, IBuilder builder);
}