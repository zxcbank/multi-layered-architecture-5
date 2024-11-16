namespace Itmo.ObjectOrientedProgramming.Lab3.MessageLogic;

public record Message
{
    public Message(int priorityLevel, string body, string header)
    {
        PriorityLevel = priorityLevel;
        Body = body;
        Header = header;
    }

    public int PriorityLevel { get; private set; }

    public string Body { get; private set; }

    public string Header { get; private set; }
}