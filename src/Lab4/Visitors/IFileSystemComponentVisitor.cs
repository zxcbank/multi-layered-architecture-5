using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileSystemComponent component);

    void Visit(DirectoryFileSystemComponent component);
}