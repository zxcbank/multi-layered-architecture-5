namespace Itmo.ObjectOrientedProgramming.Lab2;

public record SubjectType
{
    private SubjectType() { }

    public sealed record Exam : SubjectType;

    public sealed record Zachet : SubjectType;
}