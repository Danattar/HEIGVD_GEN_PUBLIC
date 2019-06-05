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
        //TODO: allow locking of this field
        private RoomQueuesHolder _roomQueuesHolder;

        public RoomManager(RoomQueuesHolder roomQueuesHolder)
        {
            _roomQueuesHolder = roomQueuesHolder;
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
            QueueMessage(roomID, roomMessage);
            //            MessageAdded?.Invoke(room, roomMessage);
            Console.WriteLine("Message added in RoomID : " + room.ID + " \n   Author : " + roomMessage.Author + " \n   Message : " + roomMessage.Message);
        }

        private void QueueMessage(string roomID, RoomMessage roomMessage)
        {
            //            _clientRoomQueues.Select(x => x.Value.Where(y => y.Key == roomID)).ToList().ForEach(x=> x.Add(roomMessage));
            //            _clientRoomQueues.ToList().ForEach(x => x.Value.ToList().Where(y => y.Key == roomID).ToList().ForEach(z => z.Value.Add(roomMessage)));
                foreach (var clientQueues in _roomQueuesHolder.ClientRoomQueues)
                {
                    if (clientQueues.Value.TryGetValue(roomID, out var messageList))
                    {
                        messageList.Add(roomMessage);
                    }
                }
            /*MessagesQueue.Add(roomMessage);
                    Console.WriteLine("Message: " + roomMessage.Message +
                                      " was added to queue for RoomID: " + roomID +
                                      " for ClientGuid: " + clientGuid);
                }*/
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
            var queue = new Dictionary<string, List<RoomMessage>>();
            queue.Add(roomID, new List<RoomMessage>());
            bool queueNotExists = _roomQueuesHolder.ClientRoomQueues.TryAdd(clientGuid, queue);
            if (queueNotExists) Console.WriteLine("Room " + roomID + " queue created for client: " + clientGuid);
        }

        private Room GetRoom(string roomID)
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
        //TODO : lock this method
        //Remark : Can return empty Dictionary
        public Dictionary<string, List<RoomMessage>> GetQueuedMessages(Guid clientGuid)
        {
            lock (_roomQueuesHolder.ClientRoomQueues)
            {
                var queueExists = _roomQueuesHolder.ClientRoomQueues.TryGetValue(clientGuid,
                    out var newMessagesQueues);
                Console.WriteLine(newMessagesQueues?.Count);
                Dictionary<string, List<RoomMessage>> copiedClientRoomQueue;
                if (queueExists && newMessagesQueues != null)
                {
                    copiedClientRoomQueue = new Dictionary<string, List<RoomMessage>>(newMessagesQueues);
/*                    foreach (string roomID in newMessagesQueues.Keys)
                    {
                        copiedClientRoomQueue.TryAdd(roomID, new List<RoomMessage>());
                        lock (newMessagesQueues)
                        {
                            foreach (RoomMessage roomMessage in newMessagesQueues[roomID])
                            {
                                copiedClientRoomQueue[roomID].Add(roomMessage);
                            }
                            newMessagesQueues[roomID].Clear();
                        }
                    }
*/                }
                else
                {
                    copiedClientRoomQueue = new Dictionary<string, List<RoomMessage>>();
                }

                Console.WriteLine(copiedClientRoomQueue?.Count);
                return copiedClientRoomQueue;
            }
        }

        #endregion
    }
}
