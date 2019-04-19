using GenProjectClientBackend.Models;
using GenProjectClientBackend.Services;
using GenProjectClientInterface.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject.Controllers
{
    public class ChatBoxViewModelController
    {
        private readonly ChatBoxService _chatBoxService;
        private readonly List<ChatBoxViewModel> _chatBoxViewModelList = new List<ChatBoxViewModel>();
        

        public ChatBoxViewModelController(ChatBoxService chatBoxService)
        {
            _chatBoxService = chatBoxService;
            chatBoxService.MessageAdded += AddChatMessageViewModel;
        }
        public ChatBoxViewModel GetChatBox()
        {
            ChatBoxViewModel chatBoxVM = CreateChatboxViewModel(_chatBoxService.GetNewChatBox());
            _chatBoxViewModelList.Add(chatBoxVM);
            return chatBoxVM;
        }
        public ChatBoxViewModel GetChatBox(int idRoom)
        {
            ChatBoxViewModel chatBoxVM = CreateChatboxViewModel(_chatBoxService.GetChatBox(idRoom));
            _chatBoxViewModelList.Add(chatBoxVM);
            return chatBoxVM;
        }

        private void AddChatMessageViewModel(ChatBox chatBox, ChatBoxMessage chatBoxMessage)
        {
            _chatBoxViewModelList.Where(x => x.Chatbox == chatBox).ToList()
                .ForEach(y => y.MessageList.Add(CreateChatBoxMessageViewModel(chatBoxMessage)));
        }

        private void SendMessage(int roomID, string message)
        {
            _chatBoxService.AddMessage(roomID, "author test1", message);
        }

        #region Factory

        private ChatBoxViewModel CreateChatboxViewModel(ChatBox chatbox)
        {
            var chatBoxVM = new ChatBoxViewModel(chatbox);
            chatBoxVM.NewMessage += SendMessage;
            return chatBoxVM;
        }
        private ChatMessageViewModel CreateChatBoxMessageViewModel(ChatBoxMessage chatBoxMessage)
        {
            return new ChatMessageViewModel(chatBoxMessage);
        }

        #endregion

    }
}
