using Abstractions.Repositories;
using Contracts.Users;
using Models.Operations;
using Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IOperationsRepository _operationsRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(
        IUserRepository repository,
        CurrentUserManager currentUserManager,
        IOperationsRepository operationsRepository,
        IAdminRepository adminRepository)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
        _operationsRepository = operationsRepository;
        _adminRepository = adminRepository;
    }

    public LoginResult Login(long userid, int pin)
    {
        User? user = _repository.FindByUserAccountId(userid);

        if (user is null)
        {
            return new LoginResult.AccountNotFound();
        }

        if (user.Pin != pin)
        {
            return new LoginResult.WrongPassword();
        }

        // _currentUserManager.User = user;

        // Console.WriteLine(_currentUserManager.User.UserId);
        // Console.WriteLine(_currentUserManager.User.MoneyAmount);
        // Console.WriteLine(_currentUserManager.User.Pin);
        return new LoginResult.SuccessUser(user);
    }

    public LoginResult Login(string pass)
    {
        if (!_adminRepository.ValidatePass(pass))
        {
            return new LoginResult.WrongPassword();
        }

        return new LoginResult.SuccessAdmin();
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

        return new WithDrawResult.Success(moneyamount);
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

        return new AddFundResult.Success(moneyamount);
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