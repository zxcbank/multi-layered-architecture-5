using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public string? Path { get; private set; }

    public string? Mode { get; private set; }

    public ConnectCommand AddMode(string mode)
    {
        Mode = mode;
        return this;
    }

    public ConnectCommand AddPath(string path)
    {
        Path = path;
        return this;
    }

    public void Execute(FileSystem fs)
    {
        if (Path != null && Mode != null)
            command.Connect(Path, Mode, fs);
    }
}