using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProjectClientBackend.Models
{
    public class ChatBoxMessage
    {
        public ChatBoxMessage(string message)
        {
            Message = message;
        }

        public string Message { get; } 
    }
}
