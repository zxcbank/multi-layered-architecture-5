namespace Contracts.Users;

public interface IUserService
{
    LoginResult Login(long userid, int pin);

    LoginResult Login(string pass);

    WithDrawResult Withdraw(decimal moneyamount);

    AddFundResult AddFudns(decimal moneyamount);

    LogOutResult LogOut();

    ViewBalanceResult ViewBalance();

    ViewHistoryResult ViewHistory();

    RegistrationResult Register(int pin);
}