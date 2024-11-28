using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public int Depth { get; private set; } = 1;

    public TreeListCommand AddDepth(int depth)
    {
        Depth = depth;
        return this;
    }

    public void Execute(FileSystem fs)
    {
        command.TreeList(Depth, fs);
    }
}