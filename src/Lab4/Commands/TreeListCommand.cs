using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ACommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public int Depth { get; private set; } = 1;

    public void AddDepth(int depth)
    {
        Depth = depth;
    }

    public override void Execute(FileSystem fs)
    {
        command.tree_list(Depth, fs);
    }

    public override void SetFlag(string flag, string value)
    {
        if (flag == "-d")
            Depth = int.Parse(value);
    }
}