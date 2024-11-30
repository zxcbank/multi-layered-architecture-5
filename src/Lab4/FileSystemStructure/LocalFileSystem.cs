using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string name)
    {
        Name = name;
        Mode = "local";
    }

    public string? Root { get; set; }

    public string? CurrentAdress { get; set; }

    public string Mode { get; }

    public string Name { get; set; }

    public void Connect(string path, string mode)
    {
        if (Mode == mode)
        {
            Root = path;
            CurrentAdress = path;
        }
    }

    public void Disconnect()
    {
        Root = null;
        CurrentAdress = null;
    }

    public void TreeGoto(string path)
    {
        CurrentAdress += path;
    }

    public void TreeList(int depth)
    {
        string? localadress = CurrentAdress;

        if (localadress is not null)
        {
            IFileSystemComponent comp = new FileSystemComponentFactory().Create(localadress);

            var visitor = new ConsoleVisitor(depth);
            comp.Accept(visitor);
        }
    }

    public void FileShow(string path, string mode)
    {
        path = CurrentAdress + path;
        if (mode == "console")
        {
            try
            {
                string content = File.ReadAllText(path);
                Console.WriteLine(content);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Ошибка: {exc.Message}");
            }
        }
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        sourcePath = CurrentAdress + sourcePath;
        destinationPath = CurrentAdress + destinationPath;
        try
        {
            File.Copy(sourcePath, destinationPath);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка копирования: {ex.Message}");
        }
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        sourcePath = CurrentAdress + sourcePath;
        destinationPath = CurrentAdress + destinationPath;
        try
        {
            File.Move(sourcePath, destinationPath);
            Console.WriteLine("Файл успешно перемещен");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка перемещения: {ex.Message}");
        }
    }

    public void FileDelete(string path)
    {
        path = CurrentAdress + path;
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("Файл успешно удален");
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка при удалении файла: {ex.Message}");
        }
    }

    public void FileRename(string path, string name)
    {
        path = CurrentAdress + path;
        string newpath = Path.GetDirectoryName(path) + name;
        try
        {
            File.Move(path, newpath);
            Console.WriteLine("Файл успешно переименован.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка переименования: {ex.Message}");
        }
    }
}