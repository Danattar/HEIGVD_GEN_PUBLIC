using GenProjectClientBackend.ServiceProjectMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProjectClientBackend.ServiceProjectMock
{
    public class Room
    {
        private static int _nextID = 1;
        internal int SessionID { get; }
        public string ChatboxName { get; set; }

        public List<RoomMessage> ChatboxList { get; } = new List<RoomMessage>();
        
        

        public Room()
        {
            SessionID = _nextID++;
        }

        internal void AddMessage(RoomMessage chatboxMessage)
        {
            ChatboxList.Add(chatboxMessage);
            NewMessage?.Invoke(chatboxMessage);
        }

        public event Action<RoomMessage> NewMessage;
    }
}
