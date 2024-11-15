﻿using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessengerDir;

public class Messenger
{
    private Message? _message;

    public void ReceiveMessage(Message message)
    {
        _message = message;
    }

    public bool HasMessage(Message message)
    {
        return _message == message;
    }

    public void PrintMessage()
    {
        Console.WriteLine("|Messenger| : {0} \n {1}", _message?.Header, _message?.Body);
    }
}