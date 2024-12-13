using Contracts.Users;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios.ViewBalance;

public class ViewBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentAccount;

    public ViewBalanceScenarioProvider(IUserService service, ICurrentUserService currentAccount)
    {
        _service = service;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ViewBalanceScenario(_service);
        return true;
    }
}