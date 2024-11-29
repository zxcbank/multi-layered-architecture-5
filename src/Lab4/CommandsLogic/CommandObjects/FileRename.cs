using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileRename : ICommand
{
    private readonly Commands command = new Commands();

    public FileRename(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public string Path { get; private set; }

    public string Name { get; private set; }

    public void Execute(IFileSystem fs)
    {
        command.FilereName(Path, Name, fs);
    }
}