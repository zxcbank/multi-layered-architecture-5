﻿using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public class ConsoleVisitor : IFileSystemComponentVisitor
{
    private int _depth;

    public ConsoleVisitor(int depth)
    {
        _depth = depth;
    }

    public void Visit(FileFileSystemComponent component)
    {
        WriteIndented(component.Name);
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        WriteIndented(component.Name);

        _depth -= 1;
        if (_depth == 0)
        {
            return;
        }

        foreach (IFileSystemComponent innerComponent in component.Components)
        {
            innerComponent.Accept(this);
        }

        _depth += 1;
    }

    private void WriteIndented(string value)
    {
        if (_depth is not 0)
        {
            Console.Write(string.Concat(Enumerable.Repeat("   ", _depth)));
            Console.Write("|–> ");
        }

        Console.WriteLine(value);
    }
}