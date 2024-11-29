using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class TreeList : ICommand
{
    private readonly Commands.Commands command = new Commands.Commands();

    private int Depth { get; set; } = 1;

    public TreeList(int depth)
    {
        Depth = depth;
    }

    public void Execute(FileSystemStructure.FileSystem fs)
    {
        command.TreeList(Depth, fs);
    }
}