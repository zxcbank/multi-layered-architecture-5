using Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserDir;

public class User(User.Attributes attrinutes) : IAddressee
{
    private readonly List<UserMessage> _messages = new List<UserMessage>();

    public Attributes Attrs { get; private set; } = attrinutes;

    public ReadOnlyCollection<UserMessage> Messages => _messages.AsReadOnly();

    public void SendMessage(Message message)
    {
        _messages.Add(new UserMessage(message));
    }

    public ReadMessageResult MarkMessageAsRead(Message message)
    {
        UserMessage? currentMessage = _messages.Find(x => x.Message == message);

        return currentMessage == null ? new ReadMessageResult.NoSuchMessage() : currentMessage.MarkMessage();
    }

    public bool HasMessage(Message message)
    {
        UserMessage? currentMessage = _messages.Find(x => x.Message == message);
        return currentMessage != null;
    }

    public class Attributes(int strength, int agility, int intelligence)
    {
        public int Strength { get; } = strength;

        public int Agility { get; } = agility;

        public int Intelligence { get; } = intelligence;
    }

    public class UserMessage(Message message)
    {
        public Message Message { get; } = message;

        public bool Read { get; private set; } = false;

        public ReadMessageResult MarkMessage()
        {
            if (!Read)
            {
                Read = !Read;
            }
            else
            {
                return new ReadMessageResult.AlreadyReadError();
            }

            return new ReadMessageResult.Success();
        }
    }
}