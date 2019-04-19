﻿using Caliburn.Micro;
using GenProjectClientBackend.Models;
using GenProjectClientBackend.ServiceProjectMock;

namespace GenProjectClientInterface.ViewModels
{
    public class ChatMessageViewModel : Screen
    {
        private readonly ChatBoxMessage _chatboxMessage;
     //   public string Author => _chatboxMessage.Author;
        public string Message => _chatboxMessage.Message;


        public ChatMessageViewModel(string author, string message)
        {
           // Author = author;
            //Message = message;
        }
        public ChatMessageViewModel(ChatBoxMessage chatboxMessage)
        {
            _chatboxMessage = chatboxMessage;
        }

        /*   public string Author { get; }
           public string Message { get; } */
        
        
    }
}