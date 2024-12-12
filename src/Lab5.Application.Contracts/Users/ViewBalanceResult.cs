namespace Contracts.Users;

public abstract record ViewBalanceResult
{
    private ViewBalanceResult() { }

    public sealed record Success(decimal Money) : ViewBalanceResult;

    public sealed record UnExpectedError : ViewBalanceResult;

    public sealed record UnAuthorised : ViewBalanceResult;
}