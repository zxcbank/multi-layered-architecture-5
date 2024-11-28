using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public string? Path { get; private set; }

    public FileDeleteCommand AddPath(string path)
    {
        Path = path;
        return this;
    }

    public void Execute(FileSystem fs)
    {
        if (Path != null)
            command.file_delete(Path, fs);
    }
}