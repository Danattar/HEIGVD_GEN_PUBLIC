using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using GenProject.ServiceMock;
using GenProject.Services;
using GenProject.ViewModelFactory;
using GenProject.ViewModels;
using SimpleInjector;

namespace GenProject 
{
    public class AppBootstrapper : BootstrapperBase
    {
        /// <summary>
        /// The IoC container instance.
        /// </summary>
        public static readonly Container ContainerInstance = new Container();
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            ContainerInstance.RegisterSingleton<IWindowManager, WindowManager>();
            ContainerInstance.RegisterSingleton<Service>();
            ContainerInstance.RegisterSingleton<ShellViewModel>();
            ContainerInstance.RegisterSingleton<DashboardViewModel>();
            ContainerInstance.RegisterSingleton<ChatboxViewModelFactory>();
            ContainerInstance.RegisterSingleton<ChatboxManager>();
            ContainerInstance.RegisterSingleton<ChatboxService>();
            ContainerInstance.Verify();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
