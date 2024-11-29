namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public abstract class FileSystem
{
    protected FileSystem(string name)
    {
        Name = name;
    }

    public string? Root { get; set; }

    public string? CurrentAdress { get; set; }

    public string? Mode { get; set; }

    public string? Name { get; set; }
}