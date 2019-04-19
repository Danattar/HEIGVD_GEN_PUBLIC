using Caliburn.Micro;
using GenProjectClientBackend.Models;
using GenProjectClientBackend.ServiceProjectMock;

namespace GenProjectClientInterface.ViewModels
{
    public class ChatMessageViewModel : Screen
    {
        private readonly ChatBoxMessage _chatboxMessage;
     //   public string Author => _chatboxMessage.Author;
        public string Message => _chatboxMessage.Message;
        public string Author => _chatboxMessage.Author;


        public ChatMessageViewModel(ChatBoxMessage chatboxMessage)
        {
            _chatboxMessage = chatboxMessage;
        }
    }
}