using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ACommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public override void Execute(FileSystem fs)
    {
        command.disconnect(fs);
    }

    public override void SetFlag(string flag, string value) { }
}