using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
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
        /// <summary>
        /// Register globals instances in IoC.
        ///  Camera type registration come from config file :
        ///  - 0 or nothing : Mock camera
        ///  - 1 : Camera UEye
        ///  - 2 : Camera Imaging Control
        /// </summary>
        protected override void Configure()
        {
            ContainerInstance.RegisterSingleton<IWindowManager, WindowManager>();
            ContainerInstance.RegisterSingleton<Service>();
            ContainerInstance.RegisterSingleton<ShellViewModel>();
            ContainerInstance.RegisterSingleton<DashboardViewModel>();
            ContainerInstance.Verify();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
