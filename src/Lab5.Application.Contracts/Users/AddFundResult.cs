namespace Contracts.Users;

public abstract record AddFundResult
{
    private AddFundResult() { }

    public sealed record Success(decimal Amount) : AddFundResult;

    public sealed record IncorrentAmount : AddFundResult;

    public sealed record UnAuthorisedError : AddFundResult;
}