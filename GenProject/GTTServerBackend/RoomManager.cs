using GTTServiceContract.Room;
using GTTServiceContract.RoomImplementation;
using System;
using System.Collections.Generic;
namespace GTTServerBackend
{
    public class RoomManager : IRoomManager
    {
        private static readonly Dictionary<string, Room> _roomList = new Dictionary<string, Room>();
        private Random _random;
        private string DEFAULT_ROOM_NUMBER = "1000";
        private RoomQueuesHolder _roomQueuesHolder;

        public RoomManager(RoomQueuesHolder roomQueuesHolder)
        {
            _roomQueuesHolder = roomQueuesHolder;
        }
        public bool IsConnected()
        {
            return true;
        }
        public void AddRoomMessage(string roomID, string author, string message)
        {
            RoomMessage roomMessage = CreateRoomMessage(author, message);
            Room room = (Room)GetRoom(roomID);
            room.AddMessage(roomMessage);
            QueueMessage(roomID, roomMessage);
            Console.WriteLine("Message added in RoomID : " + room.ID + " \n   Author : " + roomMessage.Author + " \n   Message : " + roomMessage.Message);
        }

        private void QueueMessage(string roomID, RoomMessage roomMessage)
        {
            foreach (var clientQueues in _roomQueuesHolder.ClientRoomQueues)
            {
                if (clientQueues.Value.TryGetValue(roomID, out var messageList))
                {
                    messageList.Add(roomMessage);
                }
            }
        }

        public Room AddRoom(Guid clientGuid)
        {
            return GetRoom(DEFAULT_ROOM_NUMBER, clientGuid);
        }

        public Room GetRoom(string roomID, Guid clientGuid)
        {
            Console.WriteLine("Room " + roomID + " requested by clientGuid: " + clientGuid);
            CreateQueueIfNotExists(roomID, clientGuid);
            return GetRoom(roomID);
        }

        private void CreateQueueIfNotExists(string roomID, Guid clientGuid)
        {
            _roomQueuesHolder.ClientRoomQueues.TryAdd(clientGuid, new Dictionary<string, List<RoomMessage>>());
            var queueNotExists = _roomQueuesHolder.ClientRoomQueues[clientGuid].TryAdd(roomID, new List<RoomMessage>());
            if (queueNotExists) Console.WriteLine("Room " + roomID + " queue created for client: " + clientGuid);
        }

        private Room GetRoom(string roomID)
        {
            bool r = _roomList.TryGetValue(roomID, out Room room);
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
        private RoomMessage CreateRoomMessage(string author, string message)
        {
            return new RoomMessage(author, message);
        }

        #endregion
        public Dictionary<string, List<RoomMessage>> GetQueuedMessages(Guid clientGuid)
        {
            lock (_roomQueuesHolder.ClientRoomQueues)
            {
                var queueExists = _roomQueuesHolder.ClientRoomQueues.TryGetValue(clientGuid,
                    out var newMessagesQueues);
                Dictionary<string, List<RoomMessage>> copiedClientRoomQueue =
                    (queueExists && newMessagesQueues != null) ?
                      new Dictionary<string, List<RoomMessage>>(newMessagesQueues)
                    : new Dictionary<string, List<RoomMessage>>();

                return copiedClientRoomQueue;
            }
        }

        public void ClearMessageQueue(Guid clientGuid)
        {
            lock (_roomQueuesHolder)
            {
                var queueExists = _roomQueuesHolder.ClientRoomQueues.TryGetValue(clientGuid,
                    out var newMessagesQueues);
                if (queueExists)
                {
                    foreach (string roomID in newMessagesQueues.Keys)
                    {
                        newMessagesQueues[roomID].Clear();
                    }
                }
            }
        }
    }
}
