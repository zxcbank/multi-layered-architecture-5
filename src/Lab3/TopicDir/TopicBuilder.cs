﻿using Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicDir;

public class TopicBuilder
{
    private List<IAddressee>? _addressees;

    private string? _name;

    public TopicBuilder()
    {
        _addressees = null;
        _name = null;
    }

    public TopicBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public TopicBuilder AddAdressees(IReadOnlyCollection<IAddressee> addressees)
    {
        _addressees = addressees.ToList();
        return this;
    }

    public Topic Build()
    {
        return new TopicDir.Topic(
            _name ?? throw new Exception(),
            _addressees ?? throw new Exception());
    }
}