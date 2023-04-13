using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using System.Windows.Input;
using TestSystem.Models;
using TestSystem.Utilities;

namespace TestSystem.ViewModels
{
    public class AuthorizationViewModel : ObservableObject
    {
        private UserModel userModel;
        private string email;
        private string password;
        private bool rememberPassword;
        public UserModel UserModel
        {
            get => userModel;
            set => SetProperty(ref userModel, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            private get => password;
            set => SetProperty(ref password, Encryption.GetHash(value));
        }
        public bool RememberPassword
        {
            private get => rememberPassword;
            set => SetProperty(ref rememberPassword, value);
        }
        private RelayCommand singInCommand;
        private RelayCommand registrationCommand;
        private RelayCommand forgotPasswordCommand;
        public ICommand SingInCommand
        {
            get
            {
                return singInCommand ??
                  (singInCommand = new RelayCommand(
                    (obj) => DoSingInCommand(),
                    (obj) => CanExecuteSignInCommand()
                  ));
            }
        }
        public ICommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                  (registrationCommand = new RelayCommand((obj) =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new RegistrationViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public ICommand ForgotPasswordCommand
        {
            get
            {
                return forgotPasswordCommand ??
                  (forgotPasswordCommand = new RelayCommand((obj) =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new RecoverPasswordViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        private void DoSingInCommand()
        {
            var error = userModel.TryAuthorization(Email, Password, RememberPassword);
            if (error is null)
            {
                Window mw = App.GetMainWindow(UserModel);
                mw.Show();
                App.Current.MainWindow.Closing -= MainWindowStyle.WindowStyle.ShowCloseMessage;
                App.Current.MainWindow.Close();
                App.Current.MainWindow = mw;
            }
            else
            {
                ToastNotification.ShowMessage(ToastNotification.ToastViewModel.ShowError, "Ошибка авторизации");
            }
        }
        private bool CanExecuteSignInCommand()
        {
            return !((string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password)) || (Email.Length < 6 || Password.Length < 6));
        }
        public AuthorizationViewModel()
        {
            userModel = new UserModel();
        }
    }
}
