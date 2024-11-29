using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class FileShowBuilder : IBuilder
{
    private string? Path { get; set; }

    private string? Mode { get; set; }

    public FileShowBuilder AddFlag(string flag, string mode)
    {
        if (flag == "-m")
            Mode = mode;
        return this;
    }

    public FileShowBuilder AddPath(string path)
    {
        Path = path;
        return this;
    }

    public ICommand Build()
    {
        return new FileShow(Path ?? throw new NoNullAllowedException(), Mode ?? throw new NoNullAllowedException());
    }
}