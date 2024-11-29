using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class Connect : ICommand
{
    public Connect(string path, string mode)
    {
        Mode = mode;
        Path = path;
    }

    private readonly Commands.Commands command = new Commands.Commands();

    public string Path { get; private set; }

    public string Mode { get; private set; }

    public void Execute(FileSystemStructure.FileSystem fs)
    {
        command.Connect(Path, Mode, fs);
    }
}