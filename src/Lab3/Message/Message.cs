namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public class Message
{
    public Message(Priority level, Body value, string header)
    {
        Level = level;
        Value = value;
        Header = header;
    }

    public Priority Level { get; private set; }

    public Body Value { get; private set; }

    public string Header { get; private set; }
}