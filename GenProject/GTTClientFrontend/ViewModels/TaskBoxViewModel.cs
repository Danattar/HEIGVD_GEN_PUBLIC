using Caliburn.Micro;
using System;
using System.Windows;
using System.Windows.Threading;

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

        public string Brief
        {
            get => _brief;
            set
            {
                _brief = value;
                NotifyOfPropertyChange(nameof(Brief));
            }
        }
        public string Summary
        {
            get => _summary;
            set
            {
                _summary = value;
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
            throw new NotImplementedException();
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