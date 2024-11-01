    using Itmo.ObjectOrientedProgramming.Lab2.Builders;
    using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
    using Itmo.ObjectOrientedProgramming.Lab2.Results;

    namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

    public class Lecture : IHasId
    {
        public static LectureBuilder Lecturekbuilder => new LectureBuilder();

        public Guid Id { get; private set; }

        public Guid? BaseID { get; private set; }

        public string Name { get; private set; }

        public string Criteria { get; private set; }

        public string Description { get; private set; }

        private IUser Author { get; }

        public Lecture(
            Guid? baseid,
            string name,
            IUser author,
            string criteria,
            string description)
        {
            Name = name;
            BaseID = baseid;
            Description = description;
            Criteria = criteria;
            Author = author;
            Id = Guid.NewGuid();
        }

        public ChangeLectureResult ChangeName(
            IUser user,
            string name)
        {
            if (!user.Equals(Author))
            {
                return new ChangeLectureResult.WrongAuthor();
            }
            else
            {
                Name = name;
            }

            return new ChangeLectureResult.Success();
        }

        public ChangeLectureResult ChangeDescrption(
            IUser user,
            string description)
        {
            if (!user.Equals(Author))
            {
                return new ChangeLectureResult.WrongAuthor();
            }
            else
            {
                Description = description;
            }

            return new ChangeLectureResult.Success();
        }

        public ChangeLectureResult ChangeCriteria(
            IUser user,
            string criteria)
        {
            if (!user.Equals(Author))
            {
                return new ChangeLectureResult.WrongAuthor();
            }
            else
            {
                Criteria = criteria;
            }

            return new ChangeLectureResult.Success();
        }
    }