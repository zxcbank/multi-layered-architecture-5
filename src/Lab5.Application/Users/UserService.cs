using Abstractions.Repositories;
using Contracts.Users;
using Models.Operations;
using Models.Users;

namespace Lab5.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IOperationsRepository _operationsRepository;
    private readonly CurrentUserManager _currentUserManager;
    private readonly string _adminPass;

    public UserService(
        IUserRepository repository,
        CurrentUserManager currentUserManager,
        string adminPass,
        IOperationsRepository operationsRepository)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
        _adminPass = adminPass;
        _operationsRepository = operationsRepository;
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
            _operationsRepository.InsertOperation(
                _currentUserManager.User.UserId,
                OperationType.WithdrawFunds,
                moneyamount,
                OperationResult.Fail);
            return new WithDrawResult.IncorrentAmount();
        }

        if (_currentUserManager.User.MoneyAmount < moneyamount)
        {
            _operationsRepository.InsertOperation(
                _currentUserManager.User.UserId,
                OperationType.WithdrawFunds,
                moneyamount,
                OperationResult.Fail);
            return new WithDrawResult.InsufficientFunds();
        }

        _currentUserManager.User.MoneyAmount -= moneyamount;
        _operationsRepository.InsertOperation(
            _currentUserManager.User.UserId,
            OperationType.WithdrawFunds,
            moneyamount,
            OperationResult.Success);
        _repository.ChangeBalance(-moneyamount, _currentUserManager.User.UserId);

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
            _operationsRepository.InsertOperation(
                _currentUserManager.User.UserId,
                OperationType.WithdrawFunds,
                moneyamount,
                OperationResult.Fail);
            return new AddFundResult.IncorrentAmount();
        }

        _currentUserManager.User.MoneyAmount += moneyamount;
        _operationsRepository.InsertOperation(
            _currentUserManager.User.UserId,
            OperationType.WithdrawFunds,
            moneyamount,
            OperationResult.Success);
        _repository.ChangeBalance(moneyamount, _currentUserManager.User.UserId);

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

    public ViewHistoryResult ViewHistory()
    {
        if (_currentUserManager.User is null)
        {
            return new ViewHistoryResult.UnAuthorised();
        }

        IEnumerable<Operation> myOperations =
            _operationsRepository.GetAllOperationsByAccountId(_currentUserManager.User.UserId);
        return new ViewHistoryResult.Success(myOperations);
    }

    public RegistrationResult Register(int pin)
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