using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class FileMoveBuilder : IBuilder
{
    private string? SourcePath { get; set; }

    private string? DestinationPath { get; set; }

    public FileMoveBuilder AddSource(string source)
    {
        SourcePath = source;
        return this;
    }

    public FileMoveBuilder AddDestination(string destination)
    {
        DestinationPath = destination;
        return this;
    }

    public ICommand Build()
    {
        return new FileMove(
            SourcePath ?? throw new NoNullAllowedException(),
            DestinationPath ?? throw new NoNullAllowedException());
    }
}