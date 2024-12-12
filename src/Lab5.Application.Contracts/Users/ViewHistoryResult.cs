namespace Contracts.Users;

public abstract record ViewHistoryResult
{
    private ViewHistoryResult() { }

    public sealed record Success(long Id) : ViewHistoryResult;

    public sealed record UnAuthorised : ViewHistoryResult;
}