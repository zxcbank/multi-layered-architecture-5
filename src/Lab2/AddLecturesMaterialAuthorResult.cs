namespace Itmo.ObjectOrientedProgramming.Lab2;

public record AddLecturesMaterialAuthorResult
{
    private AddLecturesMaterialAuthorResult() { }

    public sealed record Success : AddLecturesMaterialAuthorResult;

    public sealed record WrongAuthor : AddLecturesMaterialAuthorResult;
}