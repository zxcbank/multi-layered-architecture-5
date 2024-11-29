using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileShow : ICommand
{
    private readonly Commands.Commands command = new Commands.Commands();

    private string Path { get; }

    private string Mode { get; }

    public FileShow(string path, string mode)
    {
        Path = path;
        Mode = mode;
    }

    public void Execute(FileSystemStructure.FileSystem fs)
    {
        command.FileShow(Path, Mode, fs);
    }
}