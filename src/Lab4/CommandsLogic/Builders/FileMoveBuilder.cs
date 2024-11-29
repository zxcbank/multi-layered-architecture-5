using Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.CommandObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public class FileMoveBuilder : IBuilder
{
    private string? SourcePath { get; set; }

    private string? DestinationPath { get; set; }

    public IBuilder AddSource(string source)
    {
        SourcePath = source;
        return this;
    }

    public IBuilder AddDestination(string destination)
    {
        DestinationPath = destination;
        return this;
    }

    public IBuilder AddPath(string path)
    {
        return this;
    }

    public IBuilder AddName(string name)
    {
        return this;
    }

    public ICommand Build()
    {
        return new FileMove(
            SourcePath ?? throw new NoNullAllowedException(),
            DestinationPath ?? throw new NoNullAllowedException());
    }

    public IBuilder AddFLag(string flag, string value)
    {
        return this;
    }
}