using Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.Register;

public class RegistrationScenario : IScenario
{
    private readonly IUserService _userService;

    public RegistrationScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "register";

    public void Run()
    {
        int pin = AnsiConsole.Ask<int>("Enter pin for new user");

        RegistrationResult result = _userService.Register(pin);

        string message = result switch
        {
            RegistrationResult.Success => $" Successful registration",
            RegistrationResult.UnExpectedError => "UnExpectedError",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}