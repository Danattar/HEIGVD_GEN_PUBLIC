using System.Collections.Generic;

namespace GTTClientBackend.Models
{
    public class ChatBox
    {
        public string RoomID { get; }
        public string Name { get; set; }
        public List<ChatBoxMessage> RoomMessageList { get; } = new List<ChatBoxMessage>();


        internal ChatBox(string roomID)
        {
            RoomID = roomID;
        }




    }
}
