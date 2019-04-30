using System.Collections.Generic;

namespace GTTClientBackend.Models
{
    public class ChatBox
    {
        public int ID { get; }
        public string Name { get; set; }
        public List<ChatBoxMessage> RoomMessageList { get; } = new List<ChatBoxMessage>();


        internal ChatBox(int roomID)
        {
            ID = roomID;
        }

    }
}
