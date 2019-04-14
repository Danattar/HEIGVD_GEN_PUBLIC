using Caliburn.Micro;
using GenProject.ServiceMock;
using GenProject.ServiceProjectMock;
using System;

namespace GenProject.ViewModels
{
    public class ChatBoxViewModel : Screen
    {
        public BindableCollection<ChatMessageViewModel> MessageList { get; } = new BindableCollection<ChatMessageViewModel>();
        public int ChatSessionID => _chatbox.SessionID;
        public string ChatBoxName => _chatbox.ChatboxName;

        private readonly Service _service;

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

        private readonly Chatbox _chatbox;


        public ChatBoxViewModel()
        {
        }
        public ChatBoxViewModel(string name, int chatSessionID, Service service)
        {
            System.Diagnostics.Trace.WriteLine(this.IsInitialized.ToString());
   //         ChatBoxName = name;
  //          ChatSessionID = chatSessionID;
            _service = service;
        }

        public ChatBoxViewModel(Chatbox chatbox)
        {
            _chatbox = chatbox;
            chatbox.NewMessage += test;
        }
        private void test(ChatboxMessage message)
        {
            MessageList.Add(new ChatMessageViewModel(message));
        }
        public void SendMessage()
        {
            //  _service.SendMessage(MessageBox, ChatSessionID, ChatBoxName);
            NewMessage(ChatSessionID, MessageBox, "test3 -> test4");
            MessageBox = string.Empty;
        }

        public void MessageListenerHandler(string message, int chatID, string transmitterRecipient)
        {
            if(ChatSessionID == chatID)
                MessageList.Add(new ChatMessageViewModel(transmitterRecipient, message));
        }

        public Action<int, string, string> NewMessage; 
    }
}