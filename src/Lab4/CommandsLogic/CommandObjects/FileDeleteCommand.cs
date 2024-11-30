using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileDeleteCommand : ICommand
{
    public FileDeleteCommand(string path)
    {
        Path = path;
    }

    private string Path { get; }

    public void Execute(IFileSystem fs)
    {
        fs.FileDelete(Path);
    }
}