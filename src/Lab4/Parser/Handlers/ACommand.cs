using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

public class ACommand
{
    public virtual void Execute(FileSystem fs) { }

    public virtual void SetFlag(string flag, string value) { }
}