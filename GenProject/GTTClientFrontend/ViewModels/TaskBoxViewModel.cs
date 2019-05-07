using Caliburn.Micro;
using System;
using System.Windows.Threading;

namespace GTTClientFrontend.ViewModels
{
    public class TaskBoxViewModel : Screen
    {
        private string _taskName;
        private string _taskDescription;
        private string _timerLabel = "Start";
        private DispatcherTimer _dispatcherTimer;
        private int _ellapsedTime;
        private TimeSpan _aMinute = new System.TimeSpan(0, 0, 10);

        public string TaskName
        {
            get => _taskName;
            set
            {
                _taskName = value;
                NotifyOfPropertyChange(nameof(TaskName));
            }
        }
        public string TaskDescription
        {
            get => _taskDescription;
            set
            {
                _taskDescription = value;
                NotifyOfPropertyChange(nameof(TaskDescription));
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

        public int EllapsedTime 
        {
            get => _ellapsedTime;
            set
            {
                _ellapsedTime = value;
                NotifyOfPropertyChange(nameof(EllapsedTime));
            }
        }

        public TaskBoxViewModel()
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
        public void Submit()
        {

        }
        public void Reset()
        {
            _taskName = string.Empty;
            _taskDescription = string.Empty;
        }

        public void OK()
        {
            TryClose(true);
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