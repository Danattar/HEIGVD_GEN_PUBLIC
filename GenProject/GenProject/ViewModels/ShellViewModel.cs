using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProjectClientInterface.ViewModels
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
