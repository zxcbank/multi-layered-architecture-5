using System.Drawing;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class ConsoleDriver : IDriver
{
    public ConsoleDriver(Color color, string text)
    {
        Color = color;
        Text = text;
    }

    public Color? Color { get; private set; }

    public string? Text { get; private set; }

    public void Flush()
    {
        Text = null;
    }

    public void SetColor(Color color)
    {
        Color = color;
    }

    public void SetText(string text)
    {
        Text = text;
    }

    public void Print()
    {
        if (Text != null && Color != null) Console.WriteLine(Rgb(Color.Value.R, Color.Value.G, Color.Value.B).Text(Text));
    }
}