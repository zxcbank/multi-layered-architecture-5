using Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public LoginScenario(IUserService userService, ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
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
                LoginResult.SuccessUser => "Successful login as user", // TODO: FIX ???
                LoginResult.WrongPassword => "Wrong Password for user",
                LoginResult.AccountNotFound => "user-account Not Found",
                _ => throw new ArgumentOutOfRangeException(nameof(result)),
            };

            if (result is LoginResult.SuccessUser t)
            {
                _currentUser.User = t.LoggedUser;
            }

            AnsiConsole.WriteLine(message);
            AnsiConsole.Ask<string>("Ok");
        }
        else if (mode == "admin")
        {
            string pass = AnsiConsole.Ask<string>("Enter admin-pass");

            LoginResult adminResult = _userService.Login(pass);

            string admin_message = adminResult switch
            {
                LoginResult.SuccessAdmin => "Successful login as admin",
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