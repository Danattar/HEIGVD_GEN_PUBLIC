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
        RoomImplementation.Room GetRoom(int roomID);
        void AddRoomMessage(int roomID, string author, string message);


    }
}
