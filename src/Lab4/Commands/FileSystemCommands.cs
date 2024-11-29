using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileSystemCommands
{
    public void Connect(string adress, string mode, FileSystem fs)
    {
        if (fs.Mode == mode)
        {
            fs.Root = adress;
            fs.CurrentAdress = adress;
        }
    }

    public void Disconnect(FileSystem fs)
    {
        fs.Root = null;
        fs.CurrentAdress = null;
    }

    public void TreeGoto(string path, FileSystem fs)
    {
        fs.CurrentAdress += path;
    }

    public void TreeList(int depth, FileSystem fs)
    {
        string? localadress = fs.CurrentAdress;

        if (localadress is not null)
        {
            IFileSystemComponent comp = new FileSystemComponentFactory().Create(localadress);

            var visitor = new ConsoleVisitor(depth);
            comp.Accept(visitor);
        }
    }

    public void FileShow(string path, string mode, FileSystem fs)
    {
        path = fs.CurrentAdress + path;
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

    public void FileCopy(string sourcePath, string destinationPath, FileSystem fs)
    {
        sourcePath = fs.CurrentAdress + sourcePath;
        destinationPath = fs.CurrentAdress + destinationPath;
        try
        {
            File.Copy(sourcePath, destinationPath);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка копирования: {ex.Message}");
        }
    }

    public void FileMove(string sourcePath, string destinationPath, FileSystem fs)
    {
        sourcePath = fs.CurrentAdress + sourcePath;
        destinationPath = fs.CurrentAdress + destinationPath;
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

    public void FileDelete(string path, FileSystem fs)
    {
        path = fs.CurrentAdress + path;
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

    public void FilereName(string path, string name, FileSystem fs)
    {
        path = fs.CurrentAdress + path;
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