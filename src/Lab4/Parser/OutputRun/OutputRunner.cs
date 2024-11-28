using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.OutputRun;

public class OutputRunner
{
    private readonly IParameterHandler _handler;

    public OutputRunner(IParameterHandler handler)
    {
        _handler = handler;
    }

    public void Run(IEnumerable<string> args)
    {
        using IEnumerator<string> request = args.GetEnumerator();
        AggregateModifier? modifier = null;

        while (request.MoveNext())
        {
            ICommandModifier? nextModifier = _handler.Handle(request);

            if (nextModifier is not null)
            {
                modifier = new AggregateModifier(modifier, nextModifier);
            }
        }

        var command = new ACommand();
        command = modifier?.Modify(command) ?? command;

        command.Execute(fs);
    }
}