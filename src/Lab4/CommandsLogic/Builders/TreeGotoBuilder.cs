using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class TreeGotoBuilder : IBuilder
{
    private string? Path { get; set; }

    public void AddPath(string path)
    {
        Path = path;
    }

    public ICommand Build()
    {
        return new TreeGoto(Path ?? throw new NoNullAllowedException());
    }
}