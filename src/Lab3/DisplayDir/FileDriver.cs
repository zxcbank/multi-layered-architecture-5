namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

public class FileDriver : IDriver
{
    public FileDriver(Tuple<byte, byte, byte> color, string text, string filepath)
    {
        Color = color;
        Text = text;
        FilePath = filepath;
    }

    public Tuple<byte, byte, byte>? Color { get; private set; }

    public string? Text { get; private set; }

    public string FilePath { get; }

    public void Flush()
    {
        Text = null;
    }

    public void Print()
    {
        string? content = Text;
        if (content != null) File.WriteAllText(FilePath, content);
    }

    public void SetColor(Tuple<byte, byte, byte> color)
    {
        Color = color;
    }

    public void SetText(string text)
    {
        Text = text;
    }
}