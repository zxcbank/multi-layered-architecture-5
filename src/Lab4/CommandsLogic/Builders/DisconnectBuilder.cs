using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class DisconnectBuilder : IBuilder
{
    public ICommand Build()
    {
        return new DisconnectCommand();
    }

    public IBuilder AddFLag(string flag, string value)
    {
        return new DisconnectBuilder();
    }

    public IBuilder AddSource(string source)
    {
        return this;
    }

    public IBuilder AddDestination(string destination)
    {
        return this;
    }

    public IBuilder AddPath(string path)
    {
        return this;
    }

    public IBuilder AddName(string name)
    {
        return this;
    }
}