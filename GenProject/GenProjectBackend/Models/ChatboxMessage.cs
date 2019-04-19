using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProjectClientBackend.Models
{
    public class ChatBoxMessage
    {
        public string Author { get; }
        public string Message { get; }
        public ChatBoxMessage(string author, string message)
        {
            Author = author;
            Message = message;
        }
    }
}
