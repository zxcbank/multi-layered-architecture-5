using Contracts.Users;
using Models.Users;

namespace Lab5.Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }

    public WithDrawResult Withdraw(decimal moneyamount)
    {
        if (User is null)
        {
            return new WithDrawResult.UnAuthorised();
        }

        if (moneyamount < 0.01M)
        {
            return new WithDrawResult.IncorrentAmount();
        }

        if (User.MoneyAmount < moneyamount)
        {
            return new WithDrawResult.InsufficientFunds();
        }

        User.MoneyAmount -= moneyamount;

        return new WithDrawResult.Success(moneyamount);
    }

    public AddFundResult AddFund(decimal moneyamount)
    {
        if (User is null)
        {
            return new AddFundResult.UnAuthorisedError();
        }

        if (moneyamount < 0.01M)
        {
            return new AddFundResult.IncorrentAmount();
        }

        User.MoneyAmount += moneyamount;

        return new AddFundResult.Success(moneyamount);
    }
}