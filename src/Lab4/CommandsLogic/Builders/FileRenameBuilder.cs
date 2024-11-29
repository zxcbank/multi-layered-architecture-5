using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class FileRenameBuilder : IBuilder
{
    private string? Path { get; set; }

    private string? Name { get; set; }

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
        Name = name;
        return this;
    }

    public ICommand Build()
    {
        return new FileRename(
            Path ?? throw new NoNullAllowedException(),
            Name ?? throw new NoNullAllowedException());
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