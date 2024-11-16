using Itmo.ObjectOrientedProgramming.Lab3.MessageLogic;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserLogic;

public class User
{
    private readonly List<UserMessage> _messages = new List<UserMessage>();

    public ReadOnlyCollection<UserMessage> Messages => _messages.AsReadOnly();

    public void ReceiveMessage(Message message)
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