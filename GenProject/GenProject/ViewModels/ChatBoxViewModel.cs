using Caliburn.Micro;
using GenProjectClientBackend.Models;
using GenProjectClientBackend.ServiceProjectMock;
using GenProjectClientBackend.ServiceProjectMock;
using System;

namespace GenProjectClientInterface.ViewModels
{
    public class ChatBoxViewModel : Screen
    {
        public BindableCollection<ChatMessageViewModel> MessageList { get; } = new BindableCollection<ChatMessageViewModel>();

        public int RoomID => Chatbox.RoomID;
        public string Name
        {
            get => Chatbox.Name;
            set => Chatbox.Name = value;
        }

     //   private readonly Service _service;

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
/*            chatBox.MessageList.ForEach(x => MessageList.Add())
            MessageList*/
        }
        public ChatBoxViewModel(int chatSessionID, string name)
        {
            System.Diagnostics.Trace.WriteLine(this.IsInitialized.ToString());
            //         ChatBoxName = name;
            //          ChatSessionID = chatSessionID;
            //     _service = service;


        }

        public ChatBoxViewModel(Room chatbox)
        {
            
           // _chatbox = chatbox;
         //   chatbox.NewMessage += test;
        }

        public void SendMessage()
        {
            NewMessage?.Invoke(RoomID, MessageBox);
            MessageBox = string.Empty;
        }
        public event Action<int, string> NewMessage; 
    }
}