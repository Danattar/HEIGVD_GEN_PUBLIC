using Caliburn.Micro;
using GTTClientFrontend.Controllers;

namespace GTTClientFrontend.ViewModels
{
    public class DashboardViewModel : Screen
    {
        private Screen _taskBox;
        public Screen TaskBox
        {
            get => _taskBox;
            set
            {
                _taskBox = value;
                NotifyOfPropertyChange(nameof(TaskBox));
            }
        }
        private ChatBoxViewModel _chatBox1;
        private double _zoomLevel = 1.2;

        public ChatBoxViewModel ChatBox1
        {
            get => _chatBox1;
            set
            {
                _chatBox1 = value;
                NotifyOfPropertyChange(nameof(ChatBox1));
            }
        }
        public ChatBoxViewModel ChatBox2 { get; }
        public double ZoomLevel
        {
            get => _zoomLevel;
            private set
            {
                _zoomLevel = value;
                NotifyOfPropertyChange(nameof(ZoomLevel));
            }
        }

        private readonly ChatBoxViewModelController _chatBoxController;
        private readonly TaskBoxViewModelController _taskBoxController;

        public DashboardViewModel(ChatBoxViewModelController chatBoxCtl, TaskBoxViewModelController taskBoxCtl)
        {
            _chatBoxController = chatBoxCtl;
            _taskBoxController = taskBoxCtl;
            TaskBox = new TaskBoxViewModel();
            //            chatBoxCtl.GetChatBoxAsync(); //TODO call this async
            // ChatBox2 = chatBoxCtl.GetChatBox(ChatBox1.RoomID); //TODO call this async
        }
        public async void AddChatBox()
        {
            ChatBox1 = await _chatBoxController.GetChatBoxAsync();
        }
        public void Zoom()
        {
            ZoomLevel = ZoomLevel < 1.5 ? 1.5 : 1;
        }
    }
}