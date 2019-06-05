using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GTTClientBackend.Models
{
    public class ChatBox
    {
        public string RoomID { get; set; }
        public string Name { get; set; }
        public List<ChatBoxMessage> RoomMessageList { get; set; } = new List<ChatBoxMessage>();

        internal ChatBox(string roomID)
        {
            RoomID = "te";//roomID;
        }

        internal ChatBox(string roomID, List<ChatBoxMessage> chatBoxMsgList)
        {
            RoomID = roomID;
            RoomMessageList = chatBoxMsgList;
        }

    }
}
