namespace Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

public class Message
{
    public Message(Priority priorityLevel, Body value, string header)
    {
        PriorityLevel = priorityLevel;
        Value = value;
        Header = header;
    }

    public Priority PriorityLevel { get; private set; }

    public Body Value { get; private set; }

    public string Header { get; private set; }
}