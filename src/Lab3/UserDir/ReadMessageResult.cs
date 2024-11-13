namespace Itmo.ObjectOrientedProgramming.Lab3.UserDir;

public record ReadMessageResult
{
    private ReadMessageResult() { }

    public sealed record Success : ReadMessageResult;

    public sealed record AlreadyReadError : ReadMessageResult;

    public sealed record NoSuchMessage : ReadMessageResult;
}