using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class ConnectBuilder : IBuilder
{
    private string? Path { get; set; }

    private string? Mode { get; set; }

    public ConnectBuilder AddPath(string path)
    {
        Path = path;
        return this;
    }

    public ConnectBuilder AddMode(string mode)
    {
        Mode = mode;
        return this;
    }

    public ConnectBuilder AddFlag(string flag, string value)
    {
        if (flag == "-m")
        {
            Mode = value;
        }

        return this;
    }

    public ICommand Build()
    {
        return new Connect(
            Path ?? throw new NoNullAllowedException(),
            Mode ?? throw new NoNullAllowedException());
    }
}