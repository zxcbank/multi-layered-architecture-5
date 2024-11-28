using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ACommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public int? Depth { get; private set; }

    public void AddDepth(int depth)
    {
        Depth = depth;
    }

    public override void Execute(FileSystem fs)
    {
        if (Depth != null)
        {
            command.tree_list(Depth, fs);
        }

    }

    public override void SetFlag(string flag, string value) { }
}