using GTTServiceContract.RoomImplementation;
using System;
using System.Collections.Generic;

namespace GTTServerBackend
{
    public class RoomQueuesHolder
    {
        public Dictionary<Guid, Dictionary<string, List<RoomMessage>>> ClientRoomQueues
        { get; } = new Dictionary<Guid, Dictionary<string, List<RoomMessage>>>();
    }
}
