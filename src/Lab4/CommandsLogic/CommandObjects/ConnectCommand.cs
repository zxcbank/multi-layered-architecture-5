using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class ConnectCommand : ICommand
{
    public ConnectCommand(string path, string mode)
    {
        Mode = mode;
        Path = path;
    }

    private string Path { get; }

    private string Mode { get; }

    public void Execute(IFileSystem fs)
    {
        fs.Connect(Path, Mode);
    }
}