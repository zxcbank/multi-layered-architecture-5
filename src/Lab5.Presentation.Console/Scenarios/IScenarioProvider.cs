using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}