using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class TreeList : ICommand
{
    private readonly Commands command = new Commands();

    public TreeList(int depth)
    {
        Depth = depth;
    }

    private int Depth { get; set; } = 1;

    public void Execute(IFileSystem fs)
    {
        command.TreeList(Depth, fs);
    }
}