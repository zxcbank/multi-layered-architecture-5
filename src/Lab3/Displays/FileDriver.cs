using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class FileDriver : IDriver
{
    public FileDriver(Color color, string text, string filepath)
    {
        Color = color;
        Text = text;
        FilePath = filepath;
    }

    public Color? Color { get; private set; }

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

    public void SetColor(Color color)
    {
        Color = color;
    }

    public void SetText(string text)
    {
        Text = text;
    }
}