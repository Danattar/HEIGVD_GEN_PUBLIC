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
        private static readonly Dictionary<string, Room> _roomList = new Dictionary<string, Room>();
        private Random _random;
        private string DEFAULT_ROOM_NUMBER = "1000";

        public RoomManager()
        {
                Console.WriteLine("New instance of RoomManager");
        }
        public bool IsConnected()
        {
            return true;
        }
        public void AddRoomMessage(string roomID, string author, string message)
        {
            RoomMessage roomMessage = CreateChatboxMessage(author, message);
            Room room = (Room)GetRoom(roomID);
            room.AddMessage(roomMessage);
            MessageAdded?.Invoke(room, roomMessage);
            Console.WriteLine("Message added in RoomID : " + room.ID + " \n   Author : " + roomMessage.Author + " \n   Message : " + roomMessage.Message);
        }

        public Room AddRoom()
        {
            return GetRoom(DEFAULT_ROOM_NUMBER);
        }

        public Room GetRoom(string roomID)
        {
            bool r = _roomList.TryGetValue(roomID, out Room room);
//            Console.WriteLine("Room Getted : " + room.ID + " For roomid : " + roomID);
            if (!r)
            {
                return AddRoom(roomID);
            }
            return room;
        }

        private Room AddRoom(string roomId)
        {
            while (_roomList.TryGetValue(roomId, out Room r))
            {
                roomId += "1";
            }
            Room room = CreateRoom(roomId);
            //todo: put below line in a method and lock it (concurential access)
            _roomList.Add(room.ID, room);
            Console.WriteLine("Room added\n   RoomID : " + _roomList[roomId].ID);
            return room;
        }

        public event Action<IRoom, IRoomMessage> MessageAdded;

        #region Factory

        private Room CreateRoom(string id)
        {
            return new Room(id);
        }
        private RoomMessage CreateChatboxMessage(string author, string message)
        {
            return new RoomMessage(author, message);
        }

        #endregion
    }
}
