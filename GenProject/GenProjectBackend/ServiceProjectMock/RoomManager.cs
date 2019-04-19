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
        private readonly List<Room> _roomList = new List<Room>();

        internal void AddChatboxMessage(int roomID, string author, string message)
        {
            RoomMessage roomMessage = CreateChatboxMessage(author, message);
            Room room = GetRoom(roomID);
            room.AddMessage(roomMessage);
            MessageAdded?.Invoke(room, roomMessage);
        }
        public Room AddRoom()
        {
            Room room = CreateRoom();
            _roomList.Add(room);
            return room;
        }
        public Room GetRoom(int roomID)
        {
            return _roomList.Where(x => x.ID == roomID).FirstOrDefault();
        }

        public event Action<Room, RoomMessage> MessageAdded;

        #region Factory

        private Room CreateRoom()
        {
            return new Room();
        }
        private RoomMessage CreateChatboxMessage(string author, string message)
        {
            return new RoomMessage(author, message);
        }

        #endregion
    }
}
