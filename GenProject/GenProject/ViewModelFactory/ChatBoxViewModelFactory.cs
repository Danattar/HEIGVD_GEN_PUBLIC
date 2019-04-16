using GenProject.ServiceMock;
using GenProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject.ViewModelFactory
{
    public class ChatboxViewModelFactory
    {
        public ChatBoxViewModel CreateChatboxViewModel(Room chatbox)
        {
            return new ChatBoxViewModel(chatbox.SessionID, chatbox.ChatboxName);

            return new ChatBoxViewModel(chatbox);
            


            //return new ChatBoxViewModel("Simon -> Frédéric", 1, null);
        }

    }
}
