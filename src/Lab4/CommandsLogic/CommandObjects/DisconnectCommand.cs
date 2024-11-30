using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;

public class DisconnectCommand : ICommand
{
    public void Execute(IFileSystem fs)
    {
        fs.Disconnect();
    }
}