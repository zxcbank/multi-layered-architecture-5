using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public string? Path { get; private set; }

    public void AddPath(string path)
    {
        Path = path;
    }

    public void Execute(FileSystem fs)
    {
        if (Path != null)
            command.TreeGoto(Path, fs);
    }
}