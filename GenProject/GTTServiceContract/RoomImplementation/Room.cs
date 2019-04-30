using GTTServiceContract.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTTServiceContract.RoomImplementation
{
    public class Room  : IRoom
    {
        private static int _nextID = 1;
        public int ID { get; }
        public string Name { get; set; }
        public List<IRoomMessage> RoomMessageList { get; } = new List<IRoomMessage>();

        public Room()
        {
            ID = _nextID++;
//            AddMessage(new RoomMessage("GTT", "Welcome to your new Room"));
        }

        public void AddMessage(IRoomMessage chatboxMessage)
        {
            RoomMessageList.Add((RoomMessage)chatboxMessage);
            NewMessage?.Invoke(chatboxMessage);
        }

        public event Action<IRoomMessage> NewMessage;
    }
}
