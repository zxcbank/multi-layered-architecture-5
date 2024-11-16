namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public record ChangeLabworkResult
{
    private ChangeLabworkResult() { }

    public sealed record Success : ChangeLabworkResult;

    public sealed record WrongAuthor : ChangeLabworkResult;
}