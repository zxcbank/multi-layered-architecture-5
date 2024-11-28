using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand : ICommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public string? SourcePath { get; private set; }

    public string? DestinationPath { get; private set; }

    public FileCopyCommand AddSource(string source)
    {
        SourcePath = source;
        return this;
    }

    public FileCopyCommand AddDestination(string destination)
    {
        DestinationPath = destination;
        return this;
    }

    public void Execute(FileSystem fs)
    {
        if (SourcePath != null && DestinationPath != null)
            command.file_copy(SourcePath, DestinationPath, fs);
    }
}