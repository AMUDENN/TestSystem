using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Utilities;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class RegistrationViewModel : ObservableObject
    {
        private UserModel userModel;
        private string name;
        private string surname;
        private string email;
        private string password;
        private string repeatPassword;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            private get => password;
            set => SetProperty(ref password, value);
        }
        public string RepeatPassword
        {
            private get => repeatPassword;
            set => SetProperty(ref repeatPassword, value);
        }

        private RelayCommand registrationCommand;
        private RelayCommand alreadyHaveAnAccountCommand;
        public ICommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                  (registrationCommand = new RelayCommand((obj) =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel()
                      {
                          DestinationVM = new AbstractMainViewModel(userModel)
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
                  (alreadyHaveAnAccountCommand = new RelayCommand((obj) =>
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
