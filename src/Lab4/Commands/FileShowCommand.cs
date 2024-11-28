using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ACommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public string? Path { get; private set; }

    public string? Mode { get; private set; }

    public void AddMode(string mode)
    {
        Mode = mode;
    }

    public void AddPath(string path)
    {
        Path = path;
    }

    public override void Execute(FileSystem fs)
    {
        if (Path != null && Mode != null)
            command.file_show(Path, Mode, fs);
    }

    public override void SetFlag(string flag, string value)
    {
        if (flag == "-m")
        {
            Mode = value;
        }
    }
}