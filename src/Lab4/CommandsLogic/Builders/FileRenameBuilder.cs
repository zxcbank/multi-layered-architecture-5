using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class FileRenameBuilder : IBuilder
{
    private string? Path { get; set; }

    private string? Name { get; set; }

    public FileRenameBuilder AddPath(string source)
    {
        Path = source;
        return this;
    }

    public FileRenameBuilder AddName(string destination)
    {
        Name = destination;
        return this;
    }

    public ICommand Build()
    {
        return new FileRename(
            Path ?? throw new NoNullAllowedException(),
            Name ?? throw new NoNullAllowedException());
    }
}