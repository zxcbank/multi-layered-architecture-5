using Contracts.Users;

using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios.ViewHistoryOfOperations;

public class ViewHistoryScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentAccount;

    public ViewHistoryScenarioProvider(IUserService service, ICurrentUserService currentAccount)
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

        scenario = new ViewHistoryScenario(_service);
        return true;
    }
}