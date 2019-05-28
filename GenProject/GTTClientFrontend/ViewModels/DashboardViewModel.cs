using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using GTTClientBackend.Services;
using GTTClientFrontend.Controllers;
using GTTServiceContract.Task;
using GTTServiceContract.TaskImplementation;

namespace GTTClientFrontend.ViewModels
{
    public class DashboardViewModel : Screen
    {
        private ChatBoxViewModel _displayedChatBox;
        private double _zoomLevel = 1.2;

        public ChatBoxViewModel DisplayedChatBox
        {
            get => _displayedChatBox;
            set
            {
                _displayedChatBox = value;
                NotifyOfPropertyChange(nameof(DisplayedChatBox));
            }
        }
        public BindableCollection<ChatBoxViewModel> ChatBoxList { get; set; } = new BindableCollection<ChatBoxViewModel>();
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
                _requestedChatBoxID = value;
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

        public DashboardViewModel(ChatBoxViewModelController chatBoxCtl, TaskBoxViewModelController taskBoxCtl, 
                                  IWindowManager windowManager, ProjectService projectService)
        {
            _chatBoxController = chatBoxCtl;
            _taskBoxController = taskBoxCtl;
            _windowManager = windowManager;
            _projectService = projectService;
            //            chatBoxCtl.GetChatBoxAsync(); //TODO call this async
            // ChatBox2 = chatBoxCtl.GetChatBox(DisplayedChatBox.RoomID); //TODO call this async
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
                    OtherTaskList.Clear();
                    BugTaskList.Clear();
                    foreach (TaskBoxViewModel t in TaskList)
                    {
                        AddTaskBoxViewModelToLists(t);
                    }
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
                DisplayedChatBox = await _chatBoxController.GetChatBoxAsync();
            }
            else
            {
                DisplayedChatBox = await _chatBoxController.GetChatBoxAsync(RequestedChatBoxID);
            }

            if (ChatBoxList.Count(x => x.RoomID == DisplayedChatBox.RoomID) <= 0)
            {
                ChatBoxList.Add(DisplayedChatBox);
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
            var b = await _projectService.GetProjectsId();
            task.Users.AddRange(a);
            task.Project.AddRange(b);

            bool? result = _windowManager.ShowDialog(task);
            if (result.HasValue)
            {
                if ((bool)result)
                {
                    TaskBoxViewModel t = await _taskBoxController.GetTaskBoxAsync(task.Brief, task.Summary, task.Assignee, task.Reviewer, task.DueDate, task.SelectedTaskType);
                    TaskList.Add(t);
                    AddTaskBoxViewModelToLists(t);

                    System.Diagnostics.Trace.WriteLine("Result is TRUE");
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("Result is FALSE");
                }
            }
        }

        private void AddTaskBoxViewModelToLists(TaskBoxViewModel t)
        {
            switch (t.SelectedTaskType)
            {
                case TaskType.Task:
                    OtherTaskList.Add(t);
                    break;
                case TaskType.Bug:
                    BugTaskList.Add(t);
                    break;
                default:
                    throw new NotImplementedException("Use of a not implemented TaskType");
            }
        }

        public BindableCollection<TaskBoxViewModel> BugTaskList { get; set; } = new BindableCollection<TaskBoxViewModel>();

        public BindableCollection<TaskBoxViewModel> OtherTaskList { get; set; } = new BindableCollection<TaskBoxViewModel>();

        private string _username;
        private int _chatBoxID = 0;
        private TaskBoxViewModel _selectedTask;
        private string _requestedChatBoxID;
        private ProjectService _projectService;

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
            var b = await _projectService.GetProjectsId();
            SelectedTask.Users.Clear();
            SelectedTask.Users.AddRange(a);
            SelectedTask.Project.Clear();
            SelectedTask.Project.AddRange(b);
            SelectedTask.SelectedAssignee = SelectedTask.Assignee;
            SelectedTask.ExpandedDetailsVisibility = Visibility.Visible;
            int selectedTaskID = SelectedTask.TaskID;

            bool? result = _windowManager.ShowDialog(SelectedTask);
            if (result.HasValue)
            {
                if ((bool)result)
                {
                    bool resultUpdate = _taskBoxController.UpdateTask(SelectedTask);
                    if (SelectedTask.PreviousSelectedTaskType != SelectedTask.SelectedTaskType)
                    {
                        switch (SelectedTask.SelectedTaskType)
                        {
                            case TaskType.Task:
//                                BugTaskList.Remove(BugTaskList.Select(x => x.TaskID == selectedTaskID).ToList().First()());
                                OtherTaskList.Add(SelectedTask);
                                BugTaskList.Remove(SelectedTask);
                                break;
                            case TaskType.Bug:
                                BugTaskList.Add(SelectedTask);
                                OtherTaskList.Remove(SelectedTask);
                                break;
                            default:
                                throw new NotImplementedException("Use of a not implemented TaskType");

                        }
                    }

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