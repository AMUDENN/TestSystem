using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class RegistrationViewModel : ObservableObject
    {
        private string name;
        private string surname;
        private string email;
        private string password;
        private string repeatPassword;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
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
        public string RepeatPassword
        {
            get { return repeatPassword; }
            set
            {
                repeatPassword = value;
                OnPropertyChanged("RememberPassword");
            }
        }

        private RelayCommand registrationCommand;
        private RelayCommand alreadyHaveAnAccountCommand;
        public ICommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                  (registrationCommand = new RelayCommand(() =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel()
                      {
                          DestinationVM = new AbstractMainViewModel()
                      });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public ICommand AlreadyHaveAnAccountCommand
        {
            get
            {
                return alreadyHaveAnAccountCommand ??
                  (alreadyHaveAnAccountCommand = new RelayCommand(() =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel()
                      {
                          DestinationVM = new AuthorizationViewModel()
                      });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public RegistrationViewModel()
        {
        }
    }
}
