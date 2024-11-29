using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class TreeGoto : ICommand
{
    private readonly Commands command = new Commands();

    public TreeGoto(string path)
    {
        Path = path;
    }

    private string Path { get; set; }

    public void Execute(IFileSystem fs)
    {
        command.TreeGoto(Path, fs);
    }
}