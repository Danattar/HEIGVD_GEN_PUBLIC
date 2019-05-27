using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTTClientBackend.Models;
using GTTClientBackend.Services;
using GTTClientFrontend.ViewModels;

namespace GTTClientFrontend.Controllers
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

        public async Task<ChatBoxViewModel> GetChatBoxAsync()
        {
            ChatBoxViewModel chatBoxVM = null;
            try
            {
                chatBoxVM = CreateChatboxViewModel(await _chatBoxService.GetNewChatBoxAsync());
                _chatBoxViewModelList.Add(chatBoxVM);
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("An error occured while retrieving a new ChatBox "
                                               + Environment.NewLine + "Message : " + e.Message
                                               + Environment.NewLine + "Stack Trace : " + e.StackTrace
                                               + Environment.NewLine + "Inner Exception : " + e.InnerException
                );
            }
            return chatBoxVM;
        }
        public async Task<ChatBoxViewModel> GetChatBoxAsync(string roomId)
        {
             ChatBoxViewModel chatBoxVM = null;
            try
            {
                chatBoxVM = CreateChatboxViewModel(await _chatBoxService.GetNewChatBoxAsync(roomId));
                _chatBoxViewModelList.Add(chatBoxVM);
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("An error occured while retrieving a new ChatBox "
                                               + Environment.NewLine + "Message : " + e.Message
                                               + Environment.NewLine + "Stack Trace : " + e.StackTrace
                                               + Environment.NewLine + "Inner Exception : " + e.InnerException
                );
            }
            return chatBoxVM;
        }

        private void AddChatMessageViewModel(ChatBox chatBox, ChatBoxMessage chatBoxMessage)
        {
            _chatBoxViewModelList.Where(x => x.Chatbox == chatBox).ToList()
                .ForEach(y => y.MessageList.Add(CreateChatBoxMessageViewModel(chatBoxMessage)));
        }

        private void SendMessage(string roomID, string message)
        {
            _chatBoxService.AddMessage(roomID, System.Security.Principal.WindowsIdentity.GetCurrent().Name, message);
        }

        #region Factory

        private ChatBoxViewModel CreateChatboxViewModel(ChatBox chatbox)
        {
            var chatBoxVM = new ChatBoxViewModel(chatbox);
            chatBoxVM.NewMessage += SendMessage;
            return chatBoxVM;
        }
        private ChatBoxMessageViewModel CreateChatBoxMessageViewModel(ChatBoxMessage chatBoxMessage)
        {
            return new ChatBoxMessageViewModel(chatBoxMessage);
        }

        #endregion

    }
}
