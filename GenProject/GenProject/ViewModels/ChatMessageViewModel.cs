﻿using Caliburn.Micro;
using GenProject.ServiceProjectMock;

namespace GenProject.ViewModels
{
    public class ChatMessageViewModel : Screen
    {
        private readonly RoomMessage _chatboxMessage;
        public string Author => _chatboxMessage.Author;
        public string Message => _chatboxMessage.Message;


        public ChatMessageViewModel(string author, string message)
        {
           // Author = author;
            //Message = message;
        }
        public ChatMessageViewModel(RoomMessage chatboxMessage)
        {
            _chatboxMessage = chatboxMessage;
        }

        /*   public string Author { get; }
           public string Message { get; } */
        
        
    }
}