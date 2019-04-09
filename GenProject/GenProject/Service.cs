using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject
{
    public class Service
    {
        public void SendMessage(string message, int chatID, string transmitterRecipient)
        {
            MessageSent?.Invoke(message, chatID, transmitterRecipient);
        }
        public event Action<string, int, string> MessageSent;
    }
}
