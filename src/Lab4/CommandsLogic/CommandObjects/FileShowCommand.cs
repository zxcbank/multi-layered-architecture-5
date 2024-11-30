using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileShowCommand : ICommand
{
    public FileShowCommand(string path, string mode)
    {
        Path = path;
        Mode = mode;
    }

    private string Path { get; }

    private string Mode { get; }

    public void Execute(IFileSystem fs)
    {
        fs.FileShow(Path, Mode);
    }
}