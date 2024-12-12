namespace Contracts.Users;

public abstract record RegistrationResult
{
    private RegistrationResult() { }

    public sealed record Success(long? Userid) : RegistrationResult;

    public sealed record UnExpectedError : RegistrationResult;

    public sealed record NoAccessError : RegistrationResult;
}