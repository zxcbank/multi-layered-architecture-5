namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public interface IFileSystem
{
    public string? Root { get; set; }

    public string? CurrentAdress { get; set; }

    public string? Mode { get; }

    public string Name { get; set; }
}