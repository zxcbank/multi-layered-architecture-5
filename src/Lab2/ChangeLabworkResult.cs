namespace Itmo.ObjectOrientedProgramming.Lab2;

public record ChangeLabworkResult
{
    private ChangeLabworkResult() { }

    public sealed record Success : ChangeLabworkResult;

    public sealed record WrongAuthor : ChangeLabworkResult;
}