using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public string? Path { get; private set; }

    public string? Mode { get; private set; }

    public void AddMode(string mode)
    {
        Mode = mode;
    }

    public ConnectCommand AddPath(string path)
    {
        Path = path;
        return this;
    }

    public void Execute(FileSystem fs)
    {
        if (Path != null && Mode != null)
            command.connect(Path, Mode, fs);
    }
}