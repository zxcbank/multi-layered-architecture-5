using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class FileDeleteBuilder : IBuilder
{
    private string? Path { get; set; }

    public FileDeleteBuilder AddPath(string path)
    {
        Path = path;
        return this;
    }

    public ICommand Build()
    {
        return new FileDelete(Path ?? throw new NoNullAllowedException());
    }
}