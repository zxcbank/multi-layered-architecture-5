namespace Contracts.Users;

public abstract record LogOutResult
{
    private LogOutResult() { }

    public sealed record Success : LogOutResult;

    public sealed record UnExpectedError : LogOutResult;
}