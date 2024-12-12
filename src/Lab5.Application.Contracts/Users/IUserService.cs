using Models.Users;

namespace Contracts.Users;

public interface IUserService
{
    LoginResult Login(long id, int pin);

    WithDrawResult Withdraw(decimal moneyamount);

    AddFundResult AddFudns(decimal moneyamount);

    LogOutResult LogOut();

    ViewBalanceResult ViewBalance();

    ViewHistoryResult GetUserIdHistory();

    RegistrationResult Register(User user);
}