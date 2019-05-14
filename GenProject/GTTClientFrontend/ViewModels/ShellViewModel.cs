using System;
using Caliburn.Micro;

namespace GTTClientFrontend.ViewModels
{
    public class ShellViewModel : Screen
    {
        public Screen MainScreen
        {
            get => _mainScreen;
            set
            {
                _mainScreen = value;
                NotifyOfPropertyChange(nameof(MainScreen));
            }
        }
        private Screen _mainScreen;
    
        public ShellViewModel()
        {
            MainScreen = AppBootstrapper.ContainerInstance.GetInstance<DashboardViewModel>();
        }
    }
}
