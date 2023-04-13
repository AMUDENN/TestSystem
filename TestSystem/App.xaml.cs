using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TestSystem.MainWindows;
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

            UserModel userModel = new UserModel();
            var error = userModel.TryConfigAuthorization();

            Window window;

            if (error is null)
            {
                window = GetMainWindow(userModel);
            }
            else
            {
                window = GetLoginWindow();
            }

            if (window is null)
                throw new Exception("something went wrong during initializing DI container. MainWindow is missing");

            window.Show();
            base.OnStartup(e);
        }

        private static void InitContainer()
        {
            ServiceCollection services = new ServiceCollection();
            //services.AddSingleton<LoginWindowViewModel>();
            //services.AddSingleton<LoginWindow>();
            //services.AddSingleton<MainWindowViewModel>();
            //services.AddSingleton<MainWindow>();
            services.AddSingleton<AuthorizationViewModel>();
            services.AddSingleton<RegistrationViewModel>();
            services.AddSingleton<RecoverPasswordViewModel>();
            services.AddSingleton<EnterRecoverCodeViewModel>();
            services.AddSingleton<ChangePasswordViewModel>();
            services.AddSingleton<AbstractMainViewModel>();

            services.AddSingleton<NavigationViewModel>();

            Container = services.BuildServiceProvider();
        }
        public static Window GetLoginWindow()
        {
            LoginWindowViewModel MainVM = new LoginWindowViewModel();
            Window window = new LoginWindow();
            window.DataContext = MainVM;
            return window;
        }
        public static Window GetMainWindow(UserModel userModel)
        {
            MainWindowViewModel MainVM = new MainWindowViewModel(Container.GetService<NavigationViewModel>() as NavigationViewModel);
            MainVM.UserModel = userModel;
            Window window = new MainWindow();
            window.DataContext = MainVM;
            return window;
        }
    }
}
