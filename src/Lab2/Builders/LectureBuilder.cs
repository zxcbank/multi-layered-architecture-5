using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class LectureBuilder
{
    private int? _baseId;

    private string? _name;

    private User? _author;

    private string? _criteria;

    private string? _description;

    public LectureBuilder()
    {
        _baseId = null;
        _name = null;
        _author = null;
        _criteria = null;
        _description = null;
    }

    public LectureBuilder(User user)
    {
        _baseId = null;
        _name = null;
        _author = user;
        _criteria = null;
        _description = null;
    }

    public IHasId AddBaseSubject(Lecture otherLecture)
    {
        _baseId = otherLecture.Id;
        _name = otherLecture.Name;

        return Build();
    }

    public LectureBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public LectureBuilder AddAuthor(User author)
    {
        _author = author;
        return this;
    }

    public LectureBuilder AddCriteria(string criteria)
    {
        _criteria = criteria;
        return this;
    }

    public LectureBuilder AddDescription(string description)
    {
        _description = description;
        return this;
    }

    public Lecture Build()
    {
        return new Lecture(
            _baseId,
            _name ?? throw new ArgumentNullException("name"),
            _author ?? throw new ArgumentNullException("author"),
            _criteria ?? throw new ArgumentNullException("criteria"),
            _description ?? throw new ArgumentNullException("description"));
    }
}