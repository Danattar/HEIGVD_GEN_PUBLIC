using Caliburn.Micro;
using System;
using System.Windows;
using System.Windows.Threading;
using GTTClientBackend.Models;

namespace GTTClientFrontend.ViewModels
{
    public class TaskBoxViewModel : Screen
    {
        private string _brief;
        private string _summary;
        private string _timerLabel = "Start";
        private DispatcherTimer _dispatcherTimer;
        private int _ellapsedTime;
        private TimeSpan _aMinute = new System.TimeSpan(0, 0, 10);
        private bool _quickTask = true;
        private Visibility _expandedDetailsVisibility = Visibility.Collapsed;
        private TaskBox _taskBox;
        private string _assignee;

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


        public int EllapsedTime
        {
            get => _ellapsedTime;
            set
            {
                _ellapsedTime = value;
                NotifyOfPropertyChange(nameof(EllapsedTime));
            }
        }

        public string Assignee
        {
            get => _assignee;
            set
            {
                _assignee = value;
                NotifyOfPropertyChange((nameof(Assignee)));
            }
        }
        public TaskBoxViewModel()
        {
            _taskBox = new TaskBox();
            InitDispatcher();
        }

        private void InitDispatcher()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += Tick;
            _dispatcherTimer.Interval = _aMinute;
         }

        public TaskBoxViewModel(TaskBox taskBox)
        {
            _taskBox = taskBox;
            InitDispatcher();
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
                ShowLinkedTasks();
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
    }
}