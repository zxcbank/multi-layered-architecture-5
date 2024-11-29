using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class Disconnect : ICommand
{
    private readonly Commands command = new Commands();

    public void Execute(IFileSystem fs)
    {
        command.Disconnect(fs);
    }
}