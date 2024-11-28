using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

public interface ICommand
{
    public void Execute(FileSystem fs) { }
}