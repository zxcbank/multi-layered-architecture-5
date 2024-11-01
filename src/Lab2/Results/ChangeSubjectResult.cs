namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public record ChangeSubjectResult
{
    private ChangeSubjectResult() { }

    public sealed record Success : ChangeSubjectResult;

    public sealed record WrongAuthor : ChangeSubjectResult;
}