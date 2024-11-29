namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class LocalFileSystem : FileSystem
{
    public LocalFileSystem(string name) : base(name)
    {
        Name = name;
    }

    public new string? Root { get; set; }

    public new string? CurrentAdress { get; set; }

    public new string? Mode { get; } = "local";

    public new string? Name { get; set; }
}