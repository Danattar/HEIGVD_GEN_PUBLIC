using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenProject.ViewModels
{
    public class ShellViewModel : Screen
    {
        private Screen _mainScreen;
        public Screen MainScreen
        {
            get => _mainScreen;
            set
            {
                _mainScreen = value;
                NotifyOfPropertyChange(nameof(MainScreen));
            }
        }
        public ShellViewModel()
        {
            MainScreen = AppBootstrapper.ContainerInstance.GetInstance<DashboardViewModel>();
        }
    }
}
