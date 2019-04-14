using GenProject.ServiceMock;
using GenProject.ViewModelFactory;
using GenProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject.Services
{
    public class ChatboxService
    {
        private readonly ChatboxManager _chatboxManager;
        private readonly ChatboxViewModelFactory _chatboxViewModelFactory;

        public ChatboxService(ChatboxManager chatboxManager, ChatboxViewModelFactory chatboxViewModelFactory)
        {
            _chatboxManager = chatboxManager;
            _chatboxViewModelFactory = chatboxViewModelFactory;
        }
        private ChatBoxViewModel CreateChatboxViewModel(Chatbox chatbox)
        {
            var chatboxVM = _chatboxViewModelFactory.CreateChatboxViewModel(chatbox);
            chatboxVM.NewMessage += CreateMessage;
            return chatboxVM;
        }
        public ChatBoxViewModel CreateChatbox()
        {
            return CreateChatboxViewModel(_chatboxManager.CreateChatbox());
        }
        public ChatBoxViewModel GetChatboxViewModel(int idChatbox)
        {
            return CreateChatboxViewModel(_chatboxManager.GetChatbox(idChatbox));
        }
        public void CreateMessage(int chatSessionID, string message, string author)
        {
            _chatboxManager.CreateChatboxMessage(chatSessionID, message);
        }

        //public void SendMessage()

        

    }
}
