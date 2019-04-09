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
            initialize();
        }
        public ChatBoxViewModel(string name, int chatSessionID, Service service)
        {
            initialize();
            System.Diagnostics.Trace.WriteLine(this.IsInitialized.ToString());
            ChatBoxName = name;
            ChatSessionID = chatSessionID;
            _service = service;
        }
        private void initialize()
        {
            MessageList.Add(new ChatMessageViewModel());
            MessageList.Add(new ChatMessageViewModel());
            MessageList.Add(new ChatMessageViewModel());
        }
        public void SendMessage()
        {
            //MessageList.Add(new ChatMessageViewModel(ChatBoxName, MessageBox));
            //TODO use service to send the message to the other containers with sthe same ChatSessionID
            _service.SendMessage(MessageBox, ChatSessionID);
            MessageBox = "";
        }

        public void MessageListenerHandler(string message, int chatID)
        {
            if(ChatSessionID == chatID)
                MessageList.Add(new ChatMessageViewModel(ChatBoxName, message));
        }
    }
}