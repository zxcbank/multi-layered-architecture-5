namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class User : IAddressee
{
    public class Atributes
    {
        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Intelligence { get; private set; }

        public Atributes(int strength, int agility, int intelligence)
        {
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
        }
    }

    public class UserMessage
    {
        public bool Read { get; private set; }

        public Message.Message Message { get; private set; }

        public UserMessage(Message.Message message)
        {
            Read = false;
            Message = message;
        }

        public bool MarkMessage()
        {
            Read = !Read ? true : throw new Exception();
            return true;
        }
    }

    public Atributes Attrs { get; private set; }

    private readonly List<UserMessage> _messages;

    public void GetMessage(Message.Message message)
    {
        _messages.Add(new UserMessage(message));
    }

    public User(Atributes attrinutes)
    {
        Attrs = attrinutes;
        _messages = new List<UserMessage>();
    }

    public void MarkMessageAsRead(Message.Message message)
    {
        UserMessage? currentMessage = _messages.Find(x => x == new UserMessage(message));

        bool markMessage;
        markMessage = (currentMessage == null) ? throw new Exception() : currentMessage.MarkMessage();
    }
}