using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class TreeListBuilder : IBuilder
{
    private int? Depth { get; set; } = 1;

    public TreeListBuilder AddDepth(int depth)
    {
        Depth = depth;
        return this;
    }

    public TreeListBuilder AddFlag(string flag, string value)
    {
        if (flag == "-d")
        {
            Depth = int.Parse(value);
        }

        return this;
    }

    public ICommand Build()
    {
        return new TreeList(Depth ?? throw new NoNullAllowedException());
    }
}