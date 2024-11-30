using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileRenameCommand : ICommand
{
    public FileRenameCommand(string path, string name)
    {
        Path = path;
        Name = name;
    }

    private string Path { get; }

    private string Name { get; }

    public void Execute(IFileSystem fs)
    {
        fs.FileRename(Path, Name);
    }
}