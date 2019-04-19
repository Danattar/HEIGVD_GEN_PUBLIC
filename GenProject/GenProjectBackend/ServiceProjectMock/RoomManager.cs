using GenProjectClientBackend.ServiceProjectMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProjectClientBackend.ServiceProjectMock
{
    public class RoomManager
    {
        private readonly List<Room> _chatboxList = new List<Room>();

        public Room CreateChatbox()
        {
            _chatboxList.Add(new Room());
            return _chatboxList.Last();
        }
        public Room GetChatbox(int chatSessionID)
        {
            return _chatboxList.Where(x => x.SessionID == chatSessionID).FirstOrDefault();
        }

        internal void CreateChatboxMessage(int chatSessionID, string message)
        {
            var a = CreateChatboxMessage(message);
            var b = GetChatbox(chatSessionID);
            b.AddMessage(a);
            MessageAdded?.Invoke(b, a);
        }
        private RoomMessage CreateChatboxMessage(string message)
        {
            return new RoomMessage("test1 -> test2", message);
        }

        public Room GetRoom(int roomID)
        {
            return _chatboxList.Where(x => x.SessionID == roomID).FirstOrDefault();
        }
        public event Action<Room, RoomMessage> MessageAdded;
    }
}
