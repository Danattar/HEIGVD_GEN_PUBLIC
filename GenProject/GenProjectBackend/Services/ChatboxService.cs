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
        private readonly List<ChatBox> _chatBoxList = new List<ChatBox>();

        public ChatBoxService(RoomManager chatboxManager)//, ChatboxViewModelFactory chatboxViewModelFactory)
        {
            _chatboxManager = chatboxManager;
            chatboxManager.MessageAdded += AddMessage;
        }

        

        public void AddMessage(int roomID, string author, string message)
        {
            _chatboxManager.AddChatboxMessage(roomID, author, message);
        }
        public ChatBox GetChatBox(int roomID)
        {
            Room room = _chatboxManager.GetChatbox(roomID);
            ChatBox chatBox = CreateChatbox(room);
            room.RoomMessageList.ForEach(x => chatBox.MessageList.Add(CreateChatBoxMessage(x.Author, x.Message)));
            return chatBox;
        }
        public ChatBox GetNewChatBox()
        {
            return CreateChatbox(_chatboxManager.CreateChatbox());
        }

        private void AddMessage(Room room, RoomMessage roomMessage)
        {
            List<ChatBox> chatBoxLinkedToRoomList = _chatBoxList.Where(x => x.RoomID == room.SessionID).ToList();
            var addedChatBoxMessageList = new List<ChatBoxMessage>();
            ChatBoxMessage chatBoxMessage;
            chatBoxLinkedToRoomList.ForEach(y => 
            {
                chatBoxMessage = CreateChatBoxMessage(roomMessage.Author, roomMessage.Message);
                y.MessageList.Add(chatBoxMessage);
                MessageAdded?.Invoke(y, chatBoxMessage);
            });
        }



        public event Action<ChatBox, ChatBoxMessage> MessageAdded;




        #region Factory

        private ChatBox CreateChatbox(Room room)
        {
            var a = new ChatBox(room.SessionID);
            _chatBoxList.Add(a);
            return a;
        }
        private ChatBoxMessage CreateChatBoxMessage(string author, string message)
        {
            return new ChatBoxMessage(author, message);
        }

        #endregion



    }
}
