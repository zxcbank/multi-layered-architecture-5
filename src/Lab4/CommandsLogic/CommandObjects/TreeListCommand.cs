using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class TreeListCommand : ICommand
{
    public TreeListCommand(int depth)
    {
        Depth = depth;
    }

    private int Depth { get; }

    public void Execute(IFileSystem fs)
    {
        fs.TreeList(Depth);
    }
}