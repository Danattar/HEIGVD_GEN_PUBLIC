using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProjectClientBackend.Models
{
    public class ChatboxMessage
    {
        public ChatboxMessage(string message)
        {
            Message = message;
        }

        public string Message { get; } 
    }
}
