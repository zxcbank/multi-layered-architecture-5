namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

public interface IDriver
{
    public void Flush();

    public void Print();

    public void SetColor(Tuple<byte, byte, byte> color);

    public void SetText(string text);
}