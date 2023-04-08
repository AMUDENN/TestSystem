using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestSystem.ViewModels;

namespace TestSystem
{
    public partial class App : Application
    {
        public static IServiceProvider Container { get; protected set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            InitContainer();

            MainWindowViewModel MainVM = Container.GetService<MainWindowViewModel>() as MainWindowViewModel;
            var window = Container.GetService(typeof(MainWindow)) as MainWindow;
            if (window is null)
                throw new Exception("something went wrong during initializing DI container. MainWindow is missing");
            window.DataContext = MainVM;
            window.Show();
            base.OnStartup(e);
        }

        private static void InitContainer()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<AuthorizationViewModel>();
            services.AddSingleton<RegistrationViewModel>();
            services.AddSingleton<RecoverPasswordViewModel>();
            services.AddSingleton<EnterRecoverCodeViewModel>();
            services.AddSingleton<ChangePasswordViewModel>();
            services.AddSingleton<AbstractMainViewModel>();

            services.AddSingleton<NavigationViewModel>();

            Container = services.BuildServiceProvider();
        }
    }
}
