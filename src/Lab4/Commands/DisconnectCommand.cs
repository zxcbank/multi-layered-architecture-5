using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    private readonly FileSystemCommands command = new FileSystemCommands();

    public void Execute(FileSystem fs)
    {
        command.disconnect(fs);
    }
}