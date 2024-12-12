using Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.Withdraw;

public class WithdrawScenario : IScenario
{
    private readonly IUserService _userService;

    public WithdrawScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "withdraw";

    public void Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter withdrawing sum");

        WithDrawResult result = _userService.Withdraw(amount);

        string message = result switch
        {
            WithDrawResult.Success t => $"Successful withdrawed {t.Amount}.",
            WithDrawResult.IncorrentAmount => "Too small sum.",
            WithDrawResult.UnAuthorised => "Login please before withdrawing.",
            WithDrawResult.InsufficientFunds => "Not enought money on your account.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok? (YES/NO)");
    }
}