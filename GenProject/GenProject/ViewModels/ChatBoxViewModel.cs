using Caliburn.Micro;

namespace GenProject.ViewModels
{
    public class ChatBoxViewModel : Screen
    {
        public BindableCollection<ChatMessageViewModel> MessageList { get; } = new BindableCollection<ChatMessageViewModel>();
        public string ChatBoxName { get; }
        public int ChatSessionID { get; }
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
        public ChatBoxViewModel()
        {
        }
        public ChatBoxViewModel(string name, int chatSessionID, Service service)
        {
            System.Diagnostics.Trace.WriteLine(this.IsInitialized.ToString());
            ChatBoxName = name;
            ChatSessionID = chatSessionID;
            _service = service;
        }
        public void SendMessage()
        {
            _service.SendMessage(MessageBox, ChatSessionID, ChatBoxName);
            MessageBox = string.Empty;
        }

        public void MessageListenerHandler(string message, int chatID, string transmitterRecipient)
        {
            if(ChatSessionID == chatID)
                MessageList.Add(new ChatMessageViewModel(transmitterRecipient, message));
        }
    }
}