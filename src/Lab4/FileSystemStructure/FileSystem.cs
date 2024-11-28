namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class FileSystem
{
    private readonly FileSystemComponentFactory _factory = new FileSystemComponentFactory();

    public IFileSystemComponent Dir { get; private set; }

    public FileSystem(string name, string adress)
    {
        Name = name;
        Dir = _factory.Create(adress);
        Adress = adress;
    }

    public string Adress { get; private set; }

    public string Name { get; private set; }
}