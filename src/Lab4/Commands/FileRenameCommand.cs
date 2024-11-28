using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public string? Path { get; private set; }

    public string? Name { get; private set; }

    public FileRenameCommand AddPath(string source)
    {
        Path = source;
        return this;
    }

    public FileRenameCommand AddName(string destination)
    {
        Name = destination;
        return this;
    }

    public void Execute(FileSystem fs)
    {
        if (Path != null && Name != null)
            command.file_rename(Path, Name, fs);
    }
}