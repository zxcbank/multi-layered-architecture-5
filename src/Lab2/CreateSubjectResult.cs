namespace Itmo.ObjectOrientedProgramming.Lab2;

public record CreateSubjectResult
{
    private CreateSubjectResult() { }

    public sealed record Success() : CreateSubjectResult;

    public sealed record OverHunnaPoints : CreateSubjectResult;

    public sealed record UnderHunnaPoints : CreateSubjectResult;
}