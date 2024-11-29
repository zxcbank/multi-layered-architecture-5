using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class Disconnect : ICommand
{
    private readonly Commands.Commands command = new Commands.Commands();

    public void Execute(FileSystemStructure.FileSystem fs)
    {
        command.Disconnect(fs);
    }
}