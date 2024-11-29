using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class DisconnectBuilder : IBuilder
{
    public ICommand Build()
    {
        return new Disconnect();
    }
}