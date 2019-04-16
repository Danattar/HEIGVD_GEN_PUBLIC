using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenProjectClientBackend.ServiceProjectMock;

namespace GenProjectClientBackend.Models
{
    public class Chatbox
    {
        private Room room;

     /*   public Chatbox(Room room)
        {
            this.room = room;
        }*/

        public string Name { get; set; }
        public List<ChatboxMessage> MessageList { get; set; }
    }
}
