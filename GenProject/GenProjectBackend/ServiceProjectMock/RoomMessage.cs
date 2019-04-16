using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProjectClientBackend.ServiceProjectMock
{
    public class RoomMessage
    {
        public string Author { get; }
        public string Message { get; }
        public RoomMessage(string author, string message)
        {
            Author = author;
            Message = message;
        }


    }
}
