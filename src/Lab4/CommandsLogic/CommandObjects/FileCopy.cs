using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileCopy : ICommand
{
    private readonly Commands.Commands command = new Commands.Commands();

    public FileCopy(string sourcepath, string destinationpath)
    {
        SourcePath = sourcepath;
        DestinationPath = destinationpath;
    }

    public string SourcePath { get; private set; }

    public string DestinationPath { get; private set; }

    public void Execute(FileSystemStructure.FileSystem fs)
    {
        command.FileCopy(SourcePath, DestinationPath, fs);
    }
}