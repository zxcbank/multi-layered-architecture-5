using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class TreeGotoBuilder : IBuilder
{
    private string? Path { get; set; }

    public IBuilder AddDestination(string destination)
    {
        return this;
    }

    public IBuilder AddPath(string path)
    {
        Path = path;
        return this;
    }

    public IBuilder AddName(string name)
    {
        return this;
    }

    public ICommand Build()
    {
        return new TreeGotoCommand(Path ?? throw new NoNullAllowedException());
    }

    public IBuilder AddFLag(string flag, string value)
    {
        return this;
    }

    public IBuilder AddSource(string source)
    {
        return this;
    }
}