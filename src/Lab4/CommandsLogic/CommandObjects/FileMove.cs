using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileMove : ICommand
{
    private readonly Commands command = new Commands();

    public FileMove(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    private string SourcePath { get; set; }

    private string DestinationPath { get; set; }

    public void Execute(IFileSystem fs)
    {
        command.FileMove(SourcePath, DestinationPath, fs);
    }
}