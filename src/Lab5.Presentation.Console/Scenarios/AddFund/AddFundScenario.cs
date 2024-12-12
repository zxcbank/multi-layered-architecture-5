using Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.AddFund;

public class AddFundScenario : IScenario
{
    private readonly IUserService _userService;

    public AddFundScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "add fund";

    public void Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter sum for adding on your banl account.");

        AddFundResult result = _userService.AddFudns(amount);

        string message = result switch
        {
            AddFundResult.Success t => $"Successful added {t.Amount}.",
            AddFundResult.IncorrentAmount => "Too small sum.",
            AddFundResult.UnAuthorisedError => "login before adding.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok? (YES/NO)");
    }
}