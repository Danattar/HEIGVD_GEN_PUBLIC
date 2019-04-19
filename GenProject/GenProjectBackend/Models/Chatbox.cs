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
        //private Room room;

        /*   public Chatbox(Room room)
           {
               this.room = room;
           }*/

      //  private readonly int _sessionID;
        public Chatbox(int roomID)
        {
            //_sessionID = sessionID;
            RoomID = roomID;
        }
        
        public int RoomID { get; set; }
        public string Name { get; set; }
        public List<ChatboxMessage> MessageList { get; } = new List<ChatboxMessage>();
    }
}
