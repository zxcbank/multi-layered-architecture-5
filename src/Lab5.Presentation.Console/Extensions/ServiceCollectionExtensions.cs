using Microsoft.Extensions.DependencyInjection;
using Presentation.Scenarios;
using Presentation.Scenarios.Login;

namespace Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();

        return collection;
    }
}