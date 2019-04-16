using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject.Models
{
    public class Chatbox
    {
        public string Name { get; set; }
        public List<ChatboxMessage> MessageList { get; set; }
    }
}
