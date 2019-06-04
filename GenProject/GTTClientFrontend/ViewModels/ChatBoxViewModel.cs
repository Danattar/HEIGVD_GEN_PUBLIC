using System;
using Caliburn.Micro;
using GTTClientBackend.Models;
using GTTClientBackend.Services;

namespace GTTClientFrontend.ViewModels
{
    public class ChatBoxViewModel : Screen
    {
        public BindableCollection<ChatBoxMessageViewModel> MessageList { get; } = new BindableCollection<ChatBoxMessageViewModel>();

        public string RoomID => Chatbox.RoomID;
        public string Name
        {
            get => Chatbox.Name;
            set
            {
                Chatbox.Name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
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
        private string _selectedProject;

        internal ChatBox Chatbox { get; }
        public ChatBoxViewModel(ChatBox chatBox)
        {
            Chatbox = chatBox;
        }
        public BindableCollection<string> Project { get; set; } = new BindableCollection<string>();

        public string SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                AppBootstrapper.ContainerInstance.GetInstance<ProjectService>().LinkRoomToProject(RoomID, value);
            }
        }

        public void SendMessage()
        {
            NewMessage?.Invoke(RoomID, MessageBox);
            MessageBox = string.Empty;
        }
        public event Action<string, string> NewMessage; 
    }
}