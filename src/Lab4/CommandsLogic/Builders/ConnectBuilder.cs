using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class ConnectBuilder : IBuilder
{
    private string? Path { get; set; }

    private string? Mode { get; set; }

    public IBuilder AddDestination(string destination)
    {
        return this;
    }

    IBuilder IBuilder.AddPath(string path)
    {
        return AddPath(path);
    }

    public IBuilder AddName(string name)
    {
        return this;
    }

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

    public ICommand Build()
    {
        return new Connect(
            Path ?? throw new NoNullAllowedException(),
            Mode ?? throw new NoNullAllowedException());
    }

    public IBuilder AddFLag(string flag, string value)
    {
        if (flag == "-m")
        {
            Mode = value;
        }

        return this;
    }

    public IBuilder AddSource(string source)
    {
        return this;
    }
}