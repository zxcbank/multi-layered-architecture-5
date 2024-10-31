namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Subject
{
    public static SubjectBuilder Sb => new SubjectBuilder();

    public IReadOnlyCollection<Labwork> Labworks { get; private set; }

    public IReadOnlyCollection<Lectures> LecturesCourse { get; private set; }

    public SubjectType SubjType { get; private set; }

    public string Name { get; private set; }

    public IUser User { get; private set; }

    public Guid? Baseid { get; private set; }

    public Guid Id { get; private set; }

    public Subject(
        IEnumerable<Labwork> labworks,
        IEnumerable<Lectures> lectures,
        SubjectType subjectype,
        string name,
        IUser user,
        Guid? baseid)
    {
        Labworks = labworks.ToList();
        LecturesCourse = lectures.ToList();
        SubjType = subjectype is SubjectType.Exam ? new SubjectType.Exam() : new SubjectType.Zachet();
        Name = name;
        User = user;
    }

    public class SubjectBuilder
    {
        private IReadOnlyCollection<Labwork>? _labworks;

        private IReadOnlyCollection<Lectures>? _lectures;

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

        public SubjectBuilder AddLabworks(IEnumerable<Labwork> labworks)
        {
            _labworks = labworks.ToList();
            return this;
        }

        public SubjectBuilder AddLectures(IEnumerable<Lectures> lectures)
        {
            _lectures = lectures.ToList();
            return this;
        }

        public SubjectBuilder AddSubjectType(SubjectType type)
        {
            _subjectType = type;
            return this;
        }

        public SubjectBuilder AddSubjectType(string name)
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
            return new Subject(
                _labworks ?? throw new InvalidOperationException(),
                _lectures ?? throw new InvalidOperationException(),
                _subjectType ?? throw new InvalidOperationException(),
                _name ?? throw new InvalidOperationException(),
                _user ?? throw new InvalidOperationException(),
                _baseid);
        }
    }
}