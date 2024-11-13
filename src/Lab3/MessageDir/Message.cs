namespace Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

public class Message
{
    public Message(Priority priorityLevel, string body, string header)
    {
        PriorityLevel = priorityLevel;
        Body = body;
        Header = header;
    }

    public Priority PriorityLevel { get; private set; }

    public string Body { get; private set; }

    public string Header { get; private set; }
}