using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class Connect : ICommand
{
    private readonly Commands command = new Commands();

    public Connect(string path, string mode)
    {
        Mode = mode;
        Path = path;
    }

    private string Path { get; set; }

    private string Mode { get; set; }

    public void Execute(IFileSystem fs)
    {
        command.Connect(Path, Mode, fs);
    }
}