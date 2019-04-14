using GenProject.ServiceProjectMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject.ServiceMock
{
    public class Chatbox
    {
        private static int _nextID = 1;
        internal int SessionID { get; }
        public string ChatboxName { get; set; }

        public List<ChatboxMessage> ChatboxList { get; } = new List<ChatboxMessage>();
        
        

        public Chatbox()
        {
            SessionID = _nextID++;
        }

        internal void AddMessage(ChatboxMessage chatboxMessage)
        {
            ChatboxList.Add(chatboxMessage);
            NewMessage?.Invoke(chatboxMessage);
        }

        public event Action<ChatboxMessage> NewMessage;
    }
}
