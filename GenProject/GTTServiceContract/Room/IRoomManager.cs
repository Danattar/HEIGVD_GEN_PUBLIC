using System;
using System.Collections.Generic;
using System.Text;
using GTTServiceContract.RoomImplementation;

namespace GTTServiceContract.Room
{
    public interface IRoomManager
    {
        bool IsConnected();
        RoomImplementation.Room AddRoom();
        RoomImplementation.Room GetRoom(string roomID);
        void AddRoomMessage(string roomID, string author, string message);


    }
}
