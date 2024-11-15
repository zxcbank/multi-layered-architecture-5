using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

public class ConsoleDriver : IDriver
{
    public ConsoleDriver(Tuple<byte, byte, byte> color, string text)
    {
        Color = color;
        Text = text;
    }

    public Tuple<byte, byte, byte>? Color { get; private set; }

    public string? Text { get; private set; }

    public void Flush()
    {
        Text = null;
    }

    public void SetColor(Tuple<byte, byte, byte> color)
    {
        Color = color;
    }

    public void SetText(string text)
    {
        Text = text;
    }

    public void Print()
    {
        if (Text != null && Color != null) Console.WriteLine(Rgb(Color.Item1, Color.Item2, Color.Item3).Text(Text));
    }
}