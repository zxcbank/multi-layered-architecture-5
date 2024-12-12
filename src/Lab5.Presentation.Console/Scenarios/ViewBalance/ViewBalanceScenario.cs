using Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.ViewBalance;

public class ViewBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public ViewBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "view balance";

    public void Run()
    {
        ViewBalanceResult result = _userService.ViewBalance();

        string message = result switch
        {
            ViewBalanceResult.Success t => $"{t.Money} on your bank account.",
            ViewBalanceResult.UnAuthorised => "Login please before seeing balance.",
            ViewBalanceResult.UnExpectedError => "Unexpected error.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok? (YES/NO)");
    }
}