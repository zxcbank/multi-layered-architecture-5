using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Modifiers;

public class AggregateModifier(ICommandModifier? left, ICommandModifier right) : ICommandModifier
{
    public ACommand Modify(ACommand command)
    {
        if (left is null)
            return right.Modify(command);

        command = left.Modify(command);
        return right.Modify(command);
    }
}