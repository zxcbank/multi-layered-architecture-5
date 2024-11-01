using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class LabworkBuilder : IBuilder
        {
            private int? _points;

            private Guid? _baseId;

            private string? _name;

            private IUser? _author;

            private string? _criteria;

            private string? _description;

            public LabworkBuilder()
            {
                _baseId = null;
                _name = null;
                _author = null;
                _criteria = null;
                _description = null;
                _points = null;
            }

            public LabworkBuilder(IUser user)
            {
                _baseId = null;
                _name = null;
                _author = user;
                _criteria = null;
                _description = null;
                _points = null;
            }

            public LabworkBuilder AddBaseId(Guid id)
            {
                _baseId = id;
                return this;
            }

            public LabworkBuilder AddName(string name)
            {
                _name = name;
                return this;
            }

            public LabworkBuilder AddAuthor(IUser author)
            {
                _author = author;
                return this;
            }

            public LabworkBuilder AddCriteria(string criteria)
            {
                _criteria = criteria;
                return this;
            }

            public LabworkBuilder AddDescription(string description)
            {
                _description = description;
                return this;
            }

            public LabworkBuilder AddPoints(int points)
            {
                _points = points;
                return this;
            }

            public IHasId Build()
            {
                return new Labwork(
                    _baseId,
                    _name ?? throw new InvalidOperationException(),
                    _author ?? throw new InvalidOperationException(),
                    _criteria ?? throw new InvalidOperationException(),
                    _description ?? throw new InvalidOperationException(),
                    _points ?? throw new InvalidOperationException());
            }
        }