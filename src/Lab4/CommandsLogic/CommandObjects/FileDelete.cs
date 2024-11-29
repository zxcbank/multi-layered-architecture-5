using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileDelete : ICommand
{
    private readonly Commands.Commands command = new Commands.Commands();

    public FileDelete(string path)
    {
        Path = path;
    }

    public string Path { get; private set; }

    public void Execute(FileSystemStructure.FileSystem fs)
    {
        command.FileDelete(Path, fs);
    }
}