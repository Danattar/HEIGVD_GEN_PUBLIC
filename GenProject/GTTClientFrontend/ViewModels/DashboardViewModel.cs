using System;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using GTTClientFrontend.Controllers;
namespace GTTClientFrontend.ViewModels
{
    public class DashboardViewModel : Screen
    {
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

        public int ChatBoxID
        {
            get => _chatBoxID;
            set
            {
                _chatBoxID = value;
                NotifyOfPropertyChange(nameof(ChatBoxID));
            }
        }
        private readonly ChatBoxViewModelController _chatBoxController;
        private readonly TaskBoxViewModelController _taskBoxController;
        private IWindowManager _windowManager;

        public DashboardViewModel(ChatBoxViewModelController chatBoxCtl, TaskBoxViewModelController taskBoxCtl, IWindowManager windowManager)
        {
            _chatBoxController = chatBoxCtl;
            _taskBoxController = taskBoxCtl;
            _windowManager = windowManager;
            //            chatBoxCtl.GetChatBoxAsync(); //TODO call this async
            // ChatBox2 = chatBoxCtl.GetChatBox(ChatBox1.RoomID); //TODO call this async
        }

        public bool Login()
        {
            LoginViewModel loginScreen = new LoginViewModel();
            bool? result = _windowManager.ShowDialog(loginScreen);
            if (result.HasValue)
            {
                if ((bool)result)
                {
                    Username = loginScreen.Username;
                    _taskBoxController.LoggedInAs(loginScreen.Username);
                    return true;
                }
            }
            Username = "Anonymous";
            return false;
        }

        public async void AddChatBox()
        {
            ChatBox1 = await _chatBoxController.GetChatBoxAsync();
        }
        public void Zoom()
        {
            ZoomLevel = ZoomLevel < 1.5 ? 1.5 : 1;
        }

        public async Task AddTask()
        {
            TaskBoxViewModel task = new TaskBoxViewModel();
            bool? result = _windowManager.ShowDialog(task);
            if (result.HasValue)
            {
                if ((bool)result)
                {
                    TaskBoxViewModel t = await _taskBoxController.GetTaskBoxAsync(task.Brief, task.Summary, task.Assignee);
                    TaskList.Add(t);
                    System.Diagnostics.Trace.WriteLine("Result is TRUE");
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("Result is FALSE");
                }
            }
        }
        private string _username;
        private int _chatBoxID = 0;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                NotifyOfPropertyChange(nameof(Username));
            }
        }
        public BindableCollection<TaskBoxViewModel> TaskList { get; set; } = new BindableCollection<TaskBoxViewModel>();
    }
}