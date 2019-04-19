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
        private readonly List<Chatbox> _chatBoxList = new List<Chatbox>();

        public ChatBoxService(RoomManager chatboxManager)//, ChatboxViewModelFactory chatboxViewModelFactory)
        {
            _chatboxManager = chatboxManager;
            chatboxManager.MessageAdded += AddMessage;
        }

        

        public void AddMessage(int chatSessionID, string message, string author)
        {
            _chatboxManager.CreateChatboxMessage(chatSessionID, message);
        }
        public Chatbox GetChatBox(int roomID)
        {

            return CreateChatbox(_chatboxManager.GetChatbox(roomID));
        }
        public Chatbox GetNewChatBox()
        {
            return CreateChatbox(_chatboxManager.CreateChatbox());
        }

        private void AddMessage(Room room, RoomMessage roomMessage)
        {
            _chatBoxList.Where(x => x.RoomID == room.SessionID).ToList().ForEach(y => y.MessageList.Add(CreateChatBoxMessage(roomMessage.Message)));

        }
        #region Factory

        private Chatbox CreateChatbox(Room room)
        {
            var a = new Chatbox(room.SessionID);
            _chatBoxList.Add(a);
            return a;
        }
        private ChatboxMessage CreateChatBoxMessage(string message)
        {
            return new ChatboxMessage(message);
        }



        #endregion



    }
}
