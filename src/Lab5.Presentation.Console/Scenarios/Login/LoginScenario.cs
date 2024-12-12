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
        string mode = AnsiConsole.Ask<string>("Enter login-mode");

        if (mode == "admin")
        {
            string pass = AnsiConsole.Ask<string>("Enter admin-pass");

            LoginResult adminResult = _userService.Login(pass);

            string admin_message = adminResult switch
            {
                LoginResult.Success => "Successful login",
                LoginResult.WrongPassword => "Wrong Admin Password",
                LoginResult.AccountNotFound => "Account Not Found",
                _ => throw new ArgumentOutOfRangeException(nameof(adminResult)),
            };
            AnsiConsole.WriteLine(admin_message);
            AnsiConsole.Ask<string>("Ok");
            return;
        }

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
        AnsiConsole.Ask<string>("Ok? (YES/NO)");
    }
}