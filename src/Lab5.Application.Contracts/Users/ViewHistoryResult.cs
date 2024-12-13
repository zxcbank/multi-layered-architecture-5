using Models.Operations;

namespace Contracts.Users;

public abstract record ViewHistoryResult
{
    private ViewHistoryResult() { }

    public sealed record Success(IEnumerable<Operation> MyOperation) : ViewHistoryResult;

    public sealed record UnAuthorised : ViewHistoryResult;

    public sealed record UnExecpted : ViewHistoryResult;
}