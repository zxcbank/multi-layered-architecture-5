namespace Contracts.Users;

public abstract record RegistrationResult
{
    private RegistrationResult() { }

    public sealed record Success : RegistrationResult;

    public sealed record UnExpectedError : RegistrationResult;
}