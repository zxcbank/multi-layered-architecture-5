using Models.Users;

namespace Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; set; }

    WithDrawResult Withdraw(decimal moneyamount);

    AddFundResult AddFund(decimal moneyamount);
}