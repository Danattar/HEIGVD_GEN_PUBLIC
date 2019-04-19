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
        internal int ID { get; }
        public string Name { get; set; }
        public List<RoomMessage> RoomMessageList { get; } = new List<RoomMessage>();

        public Room()
        {
            ID = _nextID++;
        }

        internal void AddMessage(RoomMessage chatboxMessage)
        {
            RoomMessageList.Add(chatboxMessage);
            NewMessage?.Invoke(chatboxMessage);
        }

        public event Action<RoomMessage> NewMessage;
    }
}
