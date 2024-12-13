using Models.Users;

namespace Contracts.Users;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record SuccessAdmin : LoginResult;

    public sealed record SuccessUser(User LoggedUser) : LoginResult;

    public sealed record AccountNotFound : LoginResult;

    public sealed record WrongPassword : LoginResult;
}