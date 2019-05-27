using System.Collections.Generic;

namespace GTTClientBackend.Models
{
    public class ChatBox
    {
        public string ID { get; }
        public string Name { get; set; }
        public List<ChatBoxMessage> RoomMessageList { get; } = new List<ChatBoxMessage>();


        internal ChatBox(string roomID)
        {
            ID = roomID;
        }

    }
}
