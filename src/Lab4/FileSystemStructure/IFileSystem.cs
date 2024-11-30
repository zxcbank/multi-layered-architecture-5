namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public interface IFileSystem
{
    public string? Root { get; set; }

    public string? CurrentAdress { get; set; }

    public string? Mode { get; }

    public string Name { get; set; }

    void Connect(string path, string mode);

    public void Disconnect();

    public void TreeGoto(string path);

    public void TreeList(int depth);

    public void FileShow(string path, string mode);

    public void FileCopy(string sourcePath, string destinationPath);

    public void FileMove(string sourcePath, string destinationPath);

    public void FileDelete(string path);

    public void FileRename(string path, string name);
}