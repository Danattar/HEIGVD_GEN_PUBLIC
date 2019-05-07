using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using GTTClientBackend.Services;
using GTTClientFrontend.Controllers;
using GTTClientFrontend.ViewModels;
using GTTServiceContract.Room;
using JKang.IpcServiceFramework;
using SimpleInjector;

namespace GTTClientFrontend
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
            ContainerInstance.RegisterSingleton<TaskBoxViewModelController>();
            ContainerInstance.RegisterSingleton<TaskService>();


//            ContainerInstance.RegisterSingleton<RoomManager>();
            
            ContainerInstance.Verify();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            bool isSuccess = ContainerInstance.GetInstance<ChatBoxService>().CancelWorkers();
            ;

        }


    }
}
