using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TestSystem.Models;
using TestSystem.ViewModels;

namespace TestSystem
{
    public partial class App : Application
    {
        public static IServiceProvider Container { get; protected set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            InitContainer();

            //UserModel userModel = new UserModel();
            //var error = userModel.TryConfigAuthorization();

            MainWindowViewModel MainVM = Container.GetService<MainWindowViewModel>() as MainWindowViewModel;

            //if (error is null)
            //{
            //    MainVM.CurrentVM = new MainViewModel(userModel);
            //}
            //else
            //{
            //    MainVM.CurrentVM = new AuthorizationViewModel();
            //}
            MainVM.CurrentVM = new AuthorizationViewModel();
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

            Container = services.BuildServiceProvider();
        }
    }
}
