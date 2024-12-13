﻿using Contracts.Users;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios.AddFund;

public class AddFundScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentAccount;

    public AddFundScenarioProvider(IUserService service, ICurrentUserService currentAccount)
    {
        _service = service;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AddFundScenario(_service);
        return true;
    }
}