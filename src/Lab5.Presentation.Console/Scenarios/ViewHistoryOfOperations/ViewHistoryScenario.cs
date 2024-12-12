using Contracts.Users;
using Models.Operations;
using Spectre.Console;

namespace Presentation.Scenarios.ViewHistoryOfOperations;

public class ViewHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public ViewHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "view history";

    public void Run()
    {
        ViewHistoryResult result = _userService.ViewHistory();

        if (result is ViewHistoryResult.Success t)
        {
            foreach (Operation element in t.MyOperation)
            {
                AnsiConsole.WriteLine(element.ToString());
            }
        }
        else if (result is ViewHistoryResult.UnAuthorised)
        {
            AnsiConsole.WriteLine("Unanthorised access \n");
        }

        AnsiConsole.Ask<string>("Ok");
    }
}