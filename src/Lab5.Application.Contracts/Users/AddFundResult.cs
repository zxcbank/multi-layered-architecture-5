namespace Contracts.Users;

public abstract record AddFundResult
{
    private AddFundResult() { }

    public sealed record Success : AddFundResult;

    public sealed record IncorrentAmount : AddFundResult;

    public sealed record UnAuthorisedError : AddFundResult;
}