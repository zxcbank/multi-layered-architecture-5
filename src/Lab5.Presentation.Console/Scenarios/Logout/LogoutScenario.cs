using Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.Logout;

public class LogoutScenario : IScenario
{
    private readonly IUserService _userService;

    public LogoutScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "logout";

    public void Run()
    {
        LogOutResult result = _userService.LogOut();

        string message = result switch
        {
            LogOutResult.Success => "Successful logout",
            LogOutResult.UnExpectedError => "Unexpected Error",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok? (YES/NO)");
    }
}