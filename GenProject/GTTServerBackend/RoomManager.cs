using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTTServiceContract;
using GTTServiceContract.Room;
using GTTServiceContract.RoomImplementation;
namespace GTTServerBackend
{
    public class RoomManager : IRoomManager
    {
        private readonly List<Room> _roomList = new List<Room>();
        public bool IsConnected()
        {
            return true;
        }
        public void AddRoomMessage(int roomID, string author, string message)
        {
            RoomMessage roomMessage = CreateChatboxMessage(author, message);
            Room room = (Room)GetRoom(roomID);
            room.AddMessage(roomMessage);
            MessageAdded?.Invoke(room, roomMessage);
        }
        public Room AddRoom()
        {
            Room room = CreateRoom();
            _roomList.Add(room);
            Console.WriteLine("Room added");
            return room;
        }
        public Room GetRoom(int roomID)
        {
            return _roomList.Where(x => x.ID == roomID).FirstOrDefault();
        }

        public event Action<IRoom, IRoomMessage> MessageAdded;

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
