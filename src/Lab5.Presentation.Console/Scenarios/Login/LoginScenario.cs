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

        if (mode == "user")
        {
            long userid = AnsiConsole.Ask<long>("Enter your bank-id");

            int pin = AnsiConsole.Ask<int>("Enter your pin");

            LoginResult result = _userService.Login(userid, pin);

            string message = result switch
            {
                LoginResult.Success => "Successful login as user", // TODO: FIX ???
                LoginResult.WrongPassword => "Wrong Password for user", // TODO: FIX ???
                LoginResult.AccountNotFound => "user-account Not Found",
                _ => throw new ArgumentOutOfRangeException(nameof(result)),
            };

            AnsiConsole.WriteLine(message);
            AnsiConsole.Ask<string>("Ok");
        }
        else if (mode == "admin")
        {
            string pass = AnsiConsole.Ask<string>("Enter admin-pass");

            LoginResult adminResult = _userService.Login(pass);

            string admin_message = adminResult switch
            {
                LoginResult.Success => "Successful login as admin",
                LoginResult.WrongPassword => "Wrong Admin Password",
                LoginResult.AccountNotFound => "admin-Account Not Found",
                _ => throw new ArgumentOutOfRangeException(nameof(adminResult)),
            };
            AnsiConsole.WriteLine(admin_message);
            AnsiConsole.Ask<string>("Ok");
        }
        else
        {
            AnsiConsole.WriteLine("no such mode.");
            AnsiConsole.Ask<string>("Ok");
        }
    }
}