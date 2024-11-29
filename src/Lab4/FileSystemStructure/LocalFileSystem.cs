﻿namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string name)
    {
        Name = name;
        Mode = "local";
    }

    public string? Root { get; set; }

    public string? CurrentAdress { get; set; }

    public string Mode { get; }

    public string Name { get; set; }
}