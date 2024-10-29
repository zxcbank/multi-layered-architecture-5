namespace Itmo.ObjectOrientedProgramming.Lab2;

public record AddLabAuthorResult
{
    private AddLabAuthorResult() { }

    public sealed record Success : AddLabAuthorResult;

    public sealed record WrongAuthor : AddLabAuthorResult;
}