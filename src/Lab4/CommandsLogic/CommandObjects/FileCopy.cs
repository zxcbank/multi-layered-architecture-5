using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileCopy : ICommand
{
    private readonly Commands command = new Commands();

    public FileCopy(string sourcepath, string destinationpath)
    {
        SourcePath = sourcepath;
        DestinationPath = destinationpath;
    }

    private string SourcePath { get; set; }

    private string DestinationPath { get; set; }

    public void Execute(IFileSystem fs)
    {
        command.FileCopy(SourcePath, DestinationPath, fs);
    }
}