using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class FileRename : ICommand
{
    private readonly Commands.Commands command = new Commands.Commands();

    public string Path { get; private set; }

    public string Name { get; private set; }

    public FileRename(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public void Execute(FileSystemStructure.FileSystem fs)
    {
        if (Path != null && Name != null)
            command.FilereName(Path, Name, fs);
    }
}