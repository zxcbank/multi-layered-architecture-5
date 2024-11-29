using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class TreeGoto : ICommand
{
    private readonly Commands.Commands command = new Commands.Commands();

    private string Path { get; set; }

    public TreeGoto(string path)
    {
        Path = path;
    }

    public void Execute(FileSystemStructure.FileSystem fs)
    {
        command.TreeGoto(Path, fs);
    }
}