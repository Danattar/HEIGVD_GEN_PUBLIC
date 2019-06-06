using Caliburn.Micro;
using GTTClientBackend.Models;

namespace GTTClientFrontend.ViewModels
{
    public class ChatBoxMessageViewModel : Screen
    {
        private readonly ChatBoxMessage _chatboxMessage;
        public string Message => _chatboxMessage.Message;
        public string Author => _chatboxMessage.Author;

        public ChatBoxMessageViewModel(ChatBoxMessage chatboxMessage)
        {
            _chatboxMessage = chatboxMessage;
        }
    }
}