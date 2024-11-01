namespace Itmo.ObjectOrientedProgramming.Lab2;

public record ChangeLectureResult
{
    private ChangeLectureResult() { }

    public sealed record Success : ChangeLectureResult;

    public sealed record WrongAuthor : ChangeLectureResult;
}