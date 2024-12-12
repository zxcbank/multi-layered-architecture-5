using Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "login";

    public void Run()
    {
        long userid = AnsiConsole.Ask<long>("Enter your bank-id");

        int pin = AnsiConsole.Ask<int>("Enter your pin");

        LoginResult result = _userService.Login(userid, pin);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.WrongPassword => "Wrong Password",
            LoginResult.AccountNotFound => "Account Not Found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}