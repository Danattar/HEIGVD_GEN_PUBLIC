using GTTServiceContract.RoomImplementation;
using System;
using System.Collections.Generic;

namespace GTTServiceContract.Room
{
    public interface IRoom
    {
        string Name { get; set; }
        string ID { get; }
        void AddMessage(IRoomMessage chatboxMessage);
        List<RoomMessage> RoomMessageList { get; set; }
        event Action<IRoomMessage> NewMessage;
    }
}