using Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserDir;

public class User(User.Atributes attrinutes) : IAddressee
{
    private readonly List<UserMessage> messages = new List<UserMessage>();

    public Atributes Attrs { get; private set; } = attrinutes;

    public void GetMessage(Message message)
    {
        messages.Add(new UserMessage(message));
    }

    public void MarkMessageAsRead(Message message)
    {
        UserMessage? currentMessage = messages.Find(x => x == new UserMessage(message));

        bool markMessage;
        markMessage = (currentMessage == null) ? throw new Exception() : currentMessage.MarkMessage();
    }

    public class Atributes(int strength, int agility, int intelligence)
    {
        public int Strength { get; private set; } = strength;

        public int Agility { get; private set; } = agility;

        public int Intelligence { get; private set; } = intelligence;
    }

    private class UserMessage(Message message)
    {
        public Message Message { get; private set; } = message;

        private bool Read { get; set; } = false;

        public bool MarkMessage()
        {
            Read = !Read ? true : throw new Exception();
            return true;
        }
    }
}