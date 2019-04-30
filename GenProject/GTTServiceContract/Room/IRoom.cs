﻿using System;
using System.Collections.Generic;

namespace GTTServiceContract.Room
{
    public interface IRoom
    {
        string Name { get; set; }
        int ID { get; }
        void AddMessage(IRoomMessage chatboxMessage);
        List<IRoomMessage> RoomMessageList { get; }
        event Action<IRoomMessage> NewMessage;
    }
}