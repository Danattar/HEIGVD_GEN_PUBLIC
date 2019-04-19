using Caliburn.Micro;
using GenProjectClientBackend.Models;
using GenProjectClientBackend.ServiceProjectMock;
using System;

namespace GenProjectClientInterface.ViewModels
{
    public class ChatBoxViewModel : Screen
    {
        public BindableCollection<ChatBoxMessageViewModel> MessageList { get; } = new BindableCollection<ChatBoxMessageViewModel>();

        public int RoomID => Chatbox.RoomID;
        public string Name
        {
            get => Chatbox.Name;
            set => Chatbox.Name = value;
        }

        public string MessageBox
        {
            get => _messageBox;
            set
            {
                _messageBox = value;
                NotifyOfPropertyChange(nameof(MessageBox));
            }
        }
        private string _messageBox;

        internal ChatBox Chatbox { get; }
        public ChatBoxViewModel(ChatBox chatBox)
        {
            Chatbox = chatBox;
        }
        public void SendMessage()
        {
            NewMessage?.Invoke(RoomID, MessageBox);
            MessageBox = string.Empty;
        }
        public event Action<int, string> NewMessage; 
    }
}