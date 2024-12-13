using Contracts.Users;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;

    public LoginScenarioProvider(IUserService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new LoginScenario(_service);
        return true;
    }
}