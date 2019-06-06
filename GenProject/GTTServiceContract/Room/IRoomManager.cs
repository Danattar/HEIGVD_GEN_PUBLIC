using GTTServiceContract.RoomImplementation;
using System;
using System.Collections.Generic;

namespace GTTServiceContract.Room
{
    public interface IRoomManager
    {
        bool IsConnected();
        RoomImplementation.Room AddRoom(Guid _clientGuid);
        RoomImplementation.Room GetRoom(string roomID, Guid _clientGuid);
        void AddRoomMessage(string roomID, string author, string message);
        Dictionary<string, List<RoomMessage>> GetQueuedMessages(Guid clientGuid);
        void ClearMessageQueue(Guid clientGuid);
    }
}
