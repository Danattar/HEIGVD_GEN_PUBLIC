using GenProjectClientBackend.Services;
using GenProjectClientInterface.ViewModelFactory;
using GenProjectClientInterface.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject.Controllers
{
    public class ChatBoxController
    {
        private readonly ChatboxViewModelFactory _chatBoxViewModelFactory;
        private readonly ChatBoxService _chatBoxService;

        public ChatBoxController(ChatboxViewModelFactory chatBoxViewModelFactory, ChatBoxService chatBoxService)
        {
            _chatBoxViewModelFactory = chatBoxViewModelFactory;
            _chatBoxService = chatBoxService;
        }
        public ChatBoxViewModel GetChatBox()
        {
            return _chatBoxViewModelFactory.CreateChatboxViewModel(_chatBoxService.GetChat(1));
        }

    }
}
