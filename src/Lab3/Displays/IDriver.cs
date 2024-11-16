using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDriver
{
    public void Flush();

    public void Print();

    public void SetColor(Color color);

    public void SetText(string text);
}