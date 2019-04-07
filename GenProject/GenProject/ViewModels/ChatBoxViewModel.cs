using Caliburn.Micro;

namespace GenProject.ViewModels
{
    public class ChatBoxViewModel : Screen
    {
        public BindableCollection<ChatMessageViewModel> MessageList { get; } = new BindableCollection<ChatMessageViewModel>();
        public string ChatBoxName { get; }
        public int ChatSessionID { get; }

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
        public ChatBoxViewModel(string name, int chatSessionID)
        {
            initialize();
            System.Diagnostics.Trace.WriteLine(this.IsInitialized.ToString());
            ChatBoxName = name;
            ChatSessionID = chatSessionID;
        }
        private void initialize()
        {
            MessageList.Add(new ChatMessageViewModel());
            MessageList.Add(new ChatMessageViewModel());
            MessageList.Add(new ChatMessageViewModel());
        }
        public void SendMessage()
        {
            MessageList.Add(new ChatMessageViewModel(ChatBoxName, MessageBox));
            //TODO use service to send the message to the other containers with sthe same ChatSessionID

            MessageBox = "";
        }
    }
}