namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Subject : IHasId
{
    public static SubjectBuilder SbBuilder => new SubjectBuilder();

    public ObjRepo<Labwork> Labworks { get; private set; }

    public ObjRepo<Lecture> Lectures { get; private set; }

    public SubjectType SubjType { get; private set; }

    public string Name { get; private set; }

    public IUser User { get; private set; }

    public Guid? Baseid { get; private set; }

    public Guid Id { get; private set; }

    private Subject(
        ObjRepo<Labwork> labworks,
        ObjRepo<Lecture> lectures,
        SubjectType subjectype,
        string name,
        IUser user,
        Guid? baseid)
    {
        Labworks = labworks;
        Lectures = lectures;
        SubjType = subjectype;
        Name = name;
        User = user;
        Id = Guid.NewGuid();
    }

    public SubjChangeResult Change(
        IUser user,
        string name,
        ObjRepo<Labwork> labworks,
        ObjRepo<Lecture> lectures,
        SubjectType subjecttype,
        Guid baseid)
    {
        if (!user.Equals(user))
        {
            return new SubjChangeResult.WrongAuthor();
        }
        else
        {
            Name = name;
            Labworks = labworks;
            Lectures = lectures;
            SubjType = subjecttype;
            Baseid = baseid;
        }

        return new SubjChangeResult.Success();
    }

    public class SubjectBuilder
    {
        private ObjRepo<Labwork>? _labworks;

        private ObjRepo<Lecture>? _lectures;

        private SubjectType? _subjectType;

        private string? _name;

        private IUser? _user;

        private Guid? _baseid;

        public SubjectBuilder()
        {
            _labworks = null;
            _lectures = null;
            _subjectType = null;
            _name = null;
            _user = null;
            _baseid = null;
        }

        public SubjectBuilder AddLabworks(ObjRepo<Labwork> labworks)
        {
            _labworks = labworks;
            return this;
        }

        public SubjectBuilder AddLectures(ObjRepo<Lecture> obj)
        {
            _lectures = obj;
            return this;
        }

        public SubjectBuilder AddSubjectType(SubjectType type)
        {
            _subjectType = type;
            return this;
        }

        public SubjectBuilder AddName(string name)
        {
            _name = name;
            return this;
        }

        public SubjectBuilder AddUser(IUser user)
        {
            _user = user;
            return this;
        }

        public SubjectBuilder AddBaseId(Guid id)
        {
            _baseid = id;
            return this;
        }

        public Subject Build()
        {
            return TotalPoints() != 100
                ? throw new InvalidOperationException()
                : new Subject(
                _labworks ?? throw new InvalidOperationException(),
                _lectures ?? throw new InvalidOperationException(),
                _subjectType ?? throw new InvalidOperationException(),
                _name ?? throw new InvalidOperationException(),
                _user ?? throw new InvalidOperationException(),
                _baseid);
        }

        private int TotalPoints()
        {
            int labsPoints = _labworks?.Items.Sum(x => x.Points) ?? 0;
            int otherPoints = (_subjectType as SubjectType.Exam)?.Points ?? 0;
            return labsPoints + otherPoints;
        }
    }
}