﻿namespace Contracts.Users;

public abstract record WithDrawResult
{
    private WithDrawResult() { }

    public sealed record Success(decimal Amount) : WithDrawResult;

    public sealed record IncorrentAmount : WithDrawResult;

    public sealed record InsufficientFunds : WithDrawResult;

    public sealed record UnAuthorised : WithDrawResult;

    public sealed record UnExpected : WithDrawResult;
}