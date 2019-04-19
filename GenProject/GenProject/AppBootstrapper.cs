using System.Windows;
using Caliburn.Micro;
using GenProject.Controllers;
using GenProjectClientBackend.ServiceProjectMock;
using GenProjectClientBackend.Services;
using GenProjectClientInterface.ViewModels;
using SimpleInjector;

namespace GenProjectClientInterface
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
            ContainerInstance.RegisterSingleton<ShellViewModel>();

            ContainerInstance.RegisterSingleton<DashboardViewModel>();

            ContainerInstance.RegisterSingleton<ChatBoxViewModelController>();

            ContainerInstance.RegisterSingleton<ChatBoxService>();

            ContainerInstance.RegisterSingleton<RoomManager>();
            
            ContainerInstance.Verify();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
