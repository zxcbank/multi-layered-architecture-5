using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileMoveCommand : ICommand
{
    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    private string SourcePath { get; }

    private string DestinationPath { get; }

    public void Execute(IFileSystem fs)
    {
        fs.FileMove(SourcePath, DestinationPath);
    }
}