namespace Itmo.ObjectOrientedProgramming.Lab2;

public record SubjChangeResult
{
    private SubjChangeResult() { }

    public sealed record Success : SubjChangeResult;

    public sealed record WrongAuthor : SubjChangeResult;
}