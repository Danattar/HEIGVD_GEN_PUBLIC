using GenProjectClientBackend.Models;
using GenProjectClientBackend.ServiceProjectMock;
using GenProjectClientInterface.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProjectClientInterface.ViewModelFactory
{
    public class ChatboxViewModelFactory
    {
        public ChatBoxViewModel CreateChatboxViewModel(Chatbox chatbox)
        {
       //     return new ChatBoxViewModel(chatbox.SessionID, chatbox.ChatboxName);

            return new ChatBoxViewModel(chatbox);
            


            //return new ChatBoxViewModel("Simon -> Frédéric", 1, null);
        }

    }
}
