using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class TreeGotoCommand : ICommand
{
    public TreeGotoCommand(string path)
    {
        Path = path;
    }

    private string Path { get; }

    public void Execute(IFileSystem fs)
    {
        fs.TreeGoto(Path);
    }
}