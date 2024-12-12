using Contracts.Users;
using Presentation.Scenarios.ViewBalance;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios.ViewHistoryOfOperations;

public class ViewHistoryScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public ViewHistoryScenarioProvider(IUserService service, ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new ViewBalanceScenario(_service);
        return true;
    }
}