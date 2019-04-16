using GenProjectClientBackend.Models;
using GenProjectClientBackend.ServiceProjectMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenProjectClientBackend.Services
{
    public class ChatBoxService
    {
        private readonly RoomManager _chatboxManager;
   //     private readonly ChatboxViewModelFactory _chatboxViewModelFactory;

        public ChatBoxService(RoomManager chatboxManager)//, ChatboxViewModelFactory chatboxViewModelFactory)
        {
            _chatboxManager = chatboxManager;
        //    _chatboxViewModelFactory = chatboxViewModelFactory;
        }
     /*   private ChatBoxViewModel CreateChatboxViewModel(Room chatbox)
        {
            var chatboxVM = _chatboxViewModelFactory.CreateChatboxViewModel(chatbox);
            chatboxVM.NewMessage += CreateMessage;
            return chatboxVM;
        }*/
     /*   public ChatBoxViewModel CreateChatbox()
        {
            return CreateChatboxViewModel(_chatboxManager.CreateChatbox());
        }
        public ChatBoxViewModel GetChatboxViewModel(int idChatbox)
        {
            return CreateChatboxViewModel(_chatboxManager.GetChatbox(idChatbox));
        }
        */
        public void CreateMessage(int chatSessionID, string message, string author)
        {
            _chatboxManager.CreateChatboxMessage(chatSessionID, message);
        }
        public Chatbox GetChat(int roomID)
        {
         //   return new Chatbox(_chatboxManager.GetRoom(roomID));
        }


        //public void SendMessage()

        

    }
}
