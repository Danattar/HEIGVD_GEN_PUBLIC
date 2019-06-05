using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Caliburn.Micro;
using Castle.Core.Internal;
using GTTClientBackend.Models;
using GTTClientBackend.Services;
using GTTServiceContract.ProjectImplementation;
using GTTServiceContract.Task;
using GTTServiceContract.TaskImplementation;

namespace GTTClientFrontend.ViewModels
{
    public class TaskBoxViewModel : Screen
    {
        private readonly TimeSpan _aMinute = new TimeSpan(0, 0, 10);
        private string _assignee;
        private string _brief;
        private DispatcherTimer _dispatcherTimer;
        private int _ellapsedTime;
        private Visibility _expandedDetailsVisibility = Visibility.Collapsed;
        private bool _quickTask = true;
        private string _selectedAssignee;
        private string _summary;
        private readonly TaskBox _taskBox;
        private int _taskID;
        private string _timerLabel = "Start";
        public TaskType PreviousSelectedTaskType { get; set; }
        public TaskBoxViewModel()
        {
            TaskType = Enum.GetValues(typeof(TaskType)).Cast<TaskType>().ToList();
            _taskBox = new TaskBox();
            InitDispatcher();
        }

        public TaskBoxViewModel(TaskBox taskBox)
        {
                TaskType = Enum.GetValues(typeof(TaskType)).Cast<TaskType>().ToList();
            _taskBox = taskBox;
            InitDispatcher();
        }


        public string Brief
        {
            get => _taskBox.Brief;
            set
            {
                _taskBox.Brief = value;
                NotifyOfPropertyChange(nameof(Brief));
            }
        }

        public string Summary
        {
            get => _taskBox.Summary;
            set
            {
                _taskBox.Summary = value;
                NotifyOfPropertyChange(nameof(Summary));
            }
        }

        public int TaskID => _taskBox.ID;

        public string TimerLabel
        {
            get => _timerLabel;
            set
            {
                _timerLabel = value;
                NotifyOfPropertyChange(nameof(TimerLabel));
            }
        }

        public Visibility ExpandedDetailsVisibility
        {
            get => _expandedDetailsVisibility;
            set
            {
                _expandedDetailsVisibility = value;
                NotifyOfPropertyChange(nameof(ExpandedDetailsVisibility));
            }
        }

        public BindableCollection<string> Users { get; set; } = new BindableCollection<string>();
        public BindableCollection<string> Project { get; set; } = new BindableCollection<string>();

        public string SelectedProject
        {
            get => _taskBox.SelectedProject;
            set
            {
                _taskBox.SelectedProject = value;
                //Use of IoC to directly get data from ProjectService without using standard data flows. Preimplementation to demonstrate the "project" functionality to the client, will be refactored in Release 2.
                AppBootstrapper.ContainerInstance.GetInstance<ProjectService>().LinkTaskToProject(TaskID.ToString(), value);
            }
        }

        public int EllapsedTime
        {
            get => _ellapsedTime;
            set
            {
                _ellapsedTime = value;
                NotifyOfPropertyChange(nameof(EllapsedTime));
            }
        }

        public string SelectedAssignee
        {
            get => _selectedAssignee;
            set
            {
                _selectedAssignee = value;
                if (!value.IsNullOrEmpty())
                    Assignee = SelectedAssignee;
                NotifyOfPropertyChange(nameof(SelectedAssignee));
            }
        }

        public string Assignee
        {
            get => _taskBox.Assignee;
            set
            {
                _taskBox.Assignee = value;
                NotifyOfPropertyChange(nameof(Assignee));
            }
        }
        public string Reviewer
        {
            get => _taskBox.Reviewer;
            set
            {
                _taskBox.Reviewer = value;
                NotifyOfPropertyChange(nameof(Reviewer));
            }
        }

        public DateTime DueDate
        {
            get => _taskBox.DueDate;
            set
            {
                _taskBox.DueDate = value;
                NotifyOfPropertyChange(nameof(DueDate));
            }
        }

        public void TakeTask()
        {
            SelectedAssignee = AppBootstrapper.ContainerInstance.GetInstance<DashboardViewModel>().Username;
        }

        private void InitDispatcher()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += Tick;
            _dispatcherTimer.Interval = _aMinute;
        }

        public void TimerStartStop()
        {
            if (_dispatcherTimer.IsEnabled)
            {
                _dispatcherTimer.Stop();
                TimerLabel = "Start";
            }
            else
            {
                _dispatcherTimer.Start();
                TimerLabel = "Stop";
            }
        }

        public void Save()
        {
            TryClose(true);
        }

        public void Next()
        {
            if (_quickTask)
            {
                ExpandDetails();
                _quickTask = false;
            }
            else
            {
                ShowLinkedTasks();
            }
        }

        private void ExpandDetails()
        {
            ExpandedDetailsVisibility = Visibility.Visible;
        }

        private void ShowLinkedTasks()
        {
            //throw new NotImplementedException();
        }

        public void Reset()
        {
            Brief = string.Empty;
            Summary = string.Empty;
        }

        public void Cancel()
        {
            TryClose(false);
        }

        private void Tick(object sender, EventArgs e)
        {
            ++EllapsedTime;
        }
        #region ManageTaskTypeEnumCombobox

            private TaskType _selectedTaskType;

            public TaskType SelectedTaskType
            {
                get => _taskBox.TaskType;
                set
                {
                    PreviousSelectedTaskType = SelectedTaskType;
                    _taskBox.TaskType = value;
                }
            }

            public IReadOnlyList<TaskType> TaskType { get; }
        #endregion
    }
}