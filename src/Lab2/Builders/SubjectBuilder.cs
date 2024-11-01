using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

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

        public SubjectBuilder(IUser user)
        {
            _labworks = null;
            _lectures = null;
            _subjectType = null;
            _name = null;
            _user = user;
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

        public IHasId AddBaseSubject(Subject otherSubject)
        {
            _baseid = otherSubject.Id;
            _name = otherSubject.Name;
            _lectures = otherSubject.Lectures;
            _labworks = otherSubject.Labworks;
            return Build();
        }

        public Subject Build()
        {
            return TotalPoints() != 100
                ? throw new InvalidOperationException("{TotalPoints()} not equal 100")
                : new Subject(
                _labworks ?? throw new InvalidOperationException("null labworks"),
                _lectures ?? throw new InvalidOperationException("null lectures"),
                _subjectType ?? throw new InvalidOperationException("wrong subjecttype"),
                _name ?? throw new InvalidOperationException("null name"),
                _user ?? throw new InvalidOperationException("null user"),
                _baseid);
        }

        private int TotalPoints()
        {
            int labsPoints = _labworks?.Items.Sum(x => x.Points) ?? 0;
            int otherPoints = (_subjectType as SubjectType.Exam)?.Points ?? 0;
            return labsPoints + otherPoints;
        }
    }