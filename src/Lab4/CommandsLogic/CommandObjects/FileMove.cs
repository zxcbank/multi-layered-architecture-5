using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileMove : ICommand
{
    private readonly Commands.Commands command = new Commands.Commands();

    public string SourcePath { get; private set; }

    public string DestinationPath { get; private set; }

    public FileMove(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public void Execute(FileSystemStructure.FileSystem fs)
    {
        command.FileMove(SourcePath, DestinationPath, fs);
    }
}