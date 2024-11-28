using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGotoCommand : ACommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public string? Path { get; private set; }

    public string? Mode { get; private set; }

    public void AddMode(string mode)
    {
        Mode = mode;
    }

    public void AddPath(string path)
    {
        Path = path;
    }

    public override void Execute(FileSystem fs)
    {
        if (Path != null && Mode != null)
            command.tree_list(Path, fs);
    }

    public override void SetFlag(string flag, string value) { }
}