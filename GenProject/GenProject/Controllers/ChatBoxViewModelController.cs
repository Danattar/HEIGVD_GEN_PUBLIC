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

        public ChatBoxViewModelController(ChatBoxService chatBoxService)
        {
            _chatBoxService = chatBoxService;
        }
        public ChatBoxViewModel GetChatBox()
        {
            return CreateChatboxViewModel(_chatBoxService.GetNewChatBox());
        }


        #region Factory

        private ChatBoxViewModel CreateChatboxViewModel(Chatbox chatbox)
        {
            return new ChatBoxViewModel(chatbox);
        }

        #endregion

    }
}
