using GenProject.ServiceProjectMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject.ServiceMock
{
    public class RoomManager
    {
        private readonly List<Room> _chatboxList = new List<Room>();

        public Room CreateChatbox()
        {
            _chatboxList.Add(new Room());
            return _chatboxList.Last();
        }
        public Room GetChatbox(int chatSessionID)
        {
            return _chatboxList.Where(x => x.SessionID == chatSessionID).FirstOrDefault();
        }

        internal void CreateChatboxMessage(int chatSessionID, string message)
        {
            GetChatbox(chatSessionID).AddMessage(CreateChatboxMessage(message));
        }
        private RoomMessage CreateChatboxMessage(string message)
        {
            return new RoomMessage("test1 -> test2", message);
        }
    }
}
