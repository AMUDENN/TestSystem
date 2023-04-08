using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class AuthorizationViewModel : ObservableObject
    {
        private string email;
        private string password;
        private bool rememberPassword;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Password
        {
            private get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public bool RememberPassword
        {
            get { return rememberPassword; }
            set
            {
                rememberPassword = value;
                OnPropertyChanged("RememberPassword");
            }
        }
        private RelayCommand singInCommand;
        private RelayCommand registrationCommand;
        private RelayCommand forgotPasswordCommand;
        public ICommand SingInCommand
        {
            get
            {
                return singInCommand ??
                  (singInCommand = new RelayCommand(() =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AbstractMainViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public ICommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                  (registrationCommand = new RelayCommand(() =>
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
                  (forgotPasswordCommand = new RelayCommand(() =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new RecoverPasswordViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public AuthorizationViewModel()
        {
        }
    }
}
