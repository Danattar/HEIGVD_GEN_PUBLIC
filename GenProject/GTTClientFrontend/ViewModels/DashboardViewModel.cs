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

        public string RequestedChatBoxID
        {
            get => _requestedChatBoxID;
            set
            {
                _requestedChatBoxID= value;
                NotifyOfPropertyChange(nameof(RequestedChatBoxID));
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

        public async Task<bool> Login()
        {
            LoginViewModel loginScreen = new LoginViewModel();
            bool? result = _windowManager.ShowDialog(loginScreen);
            if (result.HasValue)
            {
                if ((bool)result)
                {
                    Username = loginScreen.Username;
                    _taskBoxController.LoggedInAs(loginScreen.Username);
                    TaskList.Clear();
                    TaskList.AddRange(await _taskBoxController.GetTaskBoxListForUser(Username));
                    return true;
                }
            }
            Username = "Anonymous";
            return false;
        }

        public async void AddChatBox()
        {
            if (String.IsNullOrEmpty(RequestedChatBoxID))
            {
                ChatBox1 = await _chatBoxController.GetChatBoxAsync();
            }
            else
            {
                ChatBox1 = await _chatBoxController.GetChatBoxAsync(RequestedChatBoxID);
            }
            RequestedChatBoxID = string.Empty;
        }
        public void Zoom()
        {
            ZoomLevel = ZoomLevel < 1.5 ? 1.5 : 1;
        }

        public async Task AddTask()
        {
            TaskBoxViewModel task = new TaskBoxViewModel();
            var a = await _taskBoxController.GetAllUsers();
            task.Users.AddRange(a);

            bool? result = _windowManager.ShowDialog(task);
            if (result.HasValue)
            {
                if ((bool)result)
                {
                    TaskBoxViewModel t = await _taskBoxController.GetTaskBoxAsync(task.Brief, task.Summary, task.Assignee, task.Reviewer, task.DueDate);
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
        private TaskBoxViewModel _selectedTask;
        private string _requestedChatBoxID;

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
        public TaskBoxViewModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                NotifyOfPropertyChange(nameof(SelectedTask));
            }
        }
        public async Task EditSelectedTask()
        {
            var a = await _taskBoxController.GetAllUsers();
            SelectedTask.Users.Clear();
            SelectedTask.Users.AddRange(a);
            SelectedTask.SelectedAssignee = SelectedTask.Assignee;
            SelectedTask.ExpandedDetailsVisibility = Visibility.Visible;

            bool? result = _windowManager.ShowDialog(SelectedTask);
            if (result.HasValue)
            {
                if ((bool)result)
                {
                    bool resultUpdate = _taskBoxController.UpdateTask(SelectedTask);
                    System.Diagnostics.Trace.WriteLine("Result is TRUE");
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("Result is FALSE");
                }
            }
        }

    }
}