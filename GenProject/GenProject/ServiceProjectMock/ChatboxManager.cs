using GenProject.ServiceProjectMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject.ServiceMock
{
    public class ChatboxManager
    {
        private readonly List<Chatbox> _chatboxList= new List<Chatbox>();

        public Chatbox CreateChatbox()
        {
            _chatboxList.Add(new Chatbox());
            return _chatboxList.Last();
        }
        public Chatbox GetChatbox(int chatSessionID)
        {
            return _chatboxList.Where(x => x.SessionID == chatSessionID).FirstOrDefault();
        }

        internal void CreateChatboxMessage(int chatSessionID, string message)
        {
            GetChatbox(chatSessionID).AddMessage(CreateChatboxMessage(message));
        }
        private ChatboxMessage CreateChatboxMessage(string message)
        {
            return new ChatboxMessage("test1 -> test2", message);
        }
    }
}
