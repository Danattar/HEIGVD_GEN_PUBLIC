﻿using System;
using System.Collections.Generic;
using System.Text;
using GTTServiceContract.RoomImplementation;

namespace GTTServiceContract.Room
{
    public interface IRoomManager
    {
        bool IsConnected();
        RoomImplementation.Room AddRoom(Guid _clientGuid);
        RoomImplementation.Room GetRoom(string roomID, Guid _clientGuid);
        void AddRoomMessage(string roomID, string author, string message);
        List<IRoomMessage> GetQueuedMessages(Guid clientGuid);
    }
}
