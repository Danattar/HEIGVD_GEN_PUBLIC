using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject.ServiceProjectMock
{
    public class ChatboxMessage
    {
        public string Author { get; }
        public string Message { get; }
        public ChatboxMessage(string author, string message)
        {
            Author = author;
            Message = message;
        }


    }
}
