﻿// See https://aka.ms/new-console-template for more information

using Infrastructure.Extensions;
using Lab5.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Extensions;
using Presentation.Scenarios;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 6432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

ScenarioRunner scenarioRunner = scope.ServiceProvider
    .GetRequiredService<ScenarioRunner>();

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}