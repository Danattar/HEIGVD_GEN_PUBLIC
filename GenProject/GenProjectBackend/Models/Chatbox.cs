using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenProjectClientBackend.ServiceProjectMock;

namespace GenProjectClientBackend.Models
{
    public class ChatBox
    {
        public int RoomID { get; }
        public string Name { get; set; }
        public List<ChatBoxMessage> MessageList { get; } = new List<ChatBoxMessage>();

        public ChatBox(int roomID)
        {
            RoomID = roomID;
        }
    }
}
