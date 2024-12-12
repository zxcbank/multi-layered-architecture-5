namespace Contracts.Users;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record Success : LoginResult;

    public sealed record AccountNotFound : LoginResult;

    public sealed record WrongPassword : LoginResult;
}