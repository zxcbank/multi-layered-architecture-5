using Abstractions.Repositories;
using Contracts.Users;
using Models.Users;

namespace Lab5.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;
    private readonly string _adminPass;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager, string adminPass)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
        _adminPass = adminPass;
    }

    public LoginResult Login(long userid, int pin)
    {
        User? user = _repository.FindByUserAccountId(userid);

        if (user is null)
        {
            return new LoginResult.AccountNotFound();
        }

        _currentUserManager.User = user;

        if (user.Pin != pin)
        {
            return new LoginResult.WrongPassword();
        }

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public LoginResult Login(string pass)
    {
        if (pass != _adminPass)
        {
            return new LoginResult.WrongPassword();
        }

        return new LoginResult.Success();
    }

    public WithDrawResult Withdraw(decimal moneyamount)
    {
        if (_currentUserManager.User is null)
        {
            return new WithDrawResult.UnAuthorised();
        }

        if (moneyamount < 0.01M)
        {
            return new WithDrawResult.IncorrentAmount();
        }

        if (_currentUserManager.User.MoneyAmount < moneyamount)
        {
            return new WithDrawResult.InsufficientFunds();
        }

        _currentUserManager.User.MoneyAmount -= moneyamount;

        return new WithDrawResult.Success();
    }

    public AddFundResult AddFudns(decimal moneyamount)
    {
        if (_currentUserManager.User is null)
        {
            return new AddFundResult.UnAuthorisedError();
        }

        if (moneyamount < 0.01M)
        {
            return new AddFundResult.IncorrentAmount();
        }

        _currentUserManager.User.MoneyAmount += moneyamount;

        return new AddFundResult.Success();
    }

    public LogOutResult LogOut()
    {
        _currentUserManager.User = null;

        return new LogOutResult.Success();
    }

    public ViewBalanceResult ViewBalance()
    {
        if (_currentUserManager.User == null)
        {
            return new ViewBalanceResult.UnAuthorised();
        }

        return new ViewBalanceResult.Success(_currentUserManager.User.MoneyAmount);
    }

    public ViewHistoryResult GetUserIdHistory()
    {
        if (_currentUserManager.User is null)
        {
            return new ViewHistoryResult.UnAuthorised();
        }

        return new ViewHistoryResult.Success(_currentUserManager.User.UserId);
    }

    public RegistrationResult Register(int pin, UserRole role)
    {
        if (_currentUserManager.User != null && _currentUserManager.User.Role == UserRole.User)
        {
            return new RegistrationResult.NoAccessError();
        }

        long? userid = _repository.InsertNewUser(pin, UserRole.User);

        if (userid is not null)
        {
            return new RegistrationResult.Success(userid);
        }

        return new RegistrationResult.UnExpectedError();
    }
}