using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public record CreateSubjectResult
{
    private CreateSubjectResult() { }

    public sealed record Success(Subject Subj) : CreateSubjectResult;

    public sealed record WrongPointsSumm : CreateSubjectResult;
}