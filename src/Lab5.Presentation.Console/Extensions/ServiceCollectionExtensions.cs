using Microsoft.Extensions.DependencyInjection;
using Presentation.Scenarios;
using Presentation.Scenarios.AddFund;
using Presentation.Scenarios.Login;
using Presentation.Scenarios.Logout;
using Presentation.Scenarios.Register;
using Presentation.Scenarios.ViewBalance;
using Presentation.Scenarios.ViewHistoryOfOperations;
using Presentation.Scenarios.Withdraw;

namespace Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, RegistrationScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddFundScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewHistoryScenarioProvider>();

        return collection;
    }
}