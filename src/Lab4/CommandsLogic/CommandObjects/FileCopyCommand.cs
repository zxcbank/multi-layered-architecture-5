using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileCopyCommand : ICommand
{
    public FileCopyCommand(string sourcepath, string destinationpath)
    {
        SourcePath = sourcepath;
        DestinationPath = destinationpath;
    }

    private string SourcePath { get; }

    private string DestinationPath { get; }

    public void Execute(IFileSystem fs)
    {
        fs.FileCopy(SourcePath, DestinationPath);
    }
}