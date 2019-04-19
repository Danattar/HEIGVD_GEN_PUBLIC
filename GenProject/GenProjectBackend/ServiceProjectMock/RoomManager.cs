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

        internal void AddChatboxMessage(int roomID, string author, string message)
        {
            RoomMessage roomMessage = CreateChatboxMessage(author, message);
            Room room = GetChatbox(roomID);
            room.AddMessage(roomMessage);
            MessageAdded?.Invoke(room, roomMessage);
        }
        private RoomMessage CreateChatboxMessage(string author, string message)
        {
            return new RoomMessage(author, message);
        }

        public Room GetRoom(int roomID)
        {
            return _chatboxList.Where(x => x.SessionID == roomID).FirstOrDefault();
        }
        public event Action<Room, RoomMessage> MessageAdded;
    }
}
