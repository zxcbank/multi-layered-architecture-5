using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class FileShowBuilder : IBuilder
{
    private string? Path { get; set; }

    public IBuilder AddFLag(string flag, string value)
    {
        if (flag == "-m")
            Mode = value;
        return this;
    }

    public IBuilder AddSource(string source)
    {
        return this;
    }

    public IBuilder AddDestination(string destination)
    {
        return this;
    }

    private string? Mode { get; set; }

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
        return new FileShowCommand(Path ?? throw new NoNullAllowedException(), Mode ?? throw new NoNullAllowedException());
    }
}