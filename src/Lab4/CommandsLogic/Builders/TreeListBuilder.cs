using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class TreeListBuilder : IBuilder
{
    private const int _default_depth = 1;

    private int Depth { get; set; } = _default_depth;

    public ICommand Build()
    {
        return new TreeListCommand(Depth);
    }

    public IBuilder AddFLag(string flag, string value)
    {
        if (flag == "-d")
        {
            Depth = int.Parse(value);
        }

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

    public IBuilder AddPath(string path)
    {
        return this;
    }

    public IBuilder AddName(string name)
    {
        return this;
    }
}