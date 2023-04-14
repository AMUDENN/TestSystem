using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Utilities;
using TestSystem.Models;
using System.Linq;

namespace TestSystem.ViewModels
{
    public class RegistrationViewModel : ObservableObject
    {
        private RegistrationModel registrationModel;
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
            set => SetProperty(ref password, Encryption.GetHash(value));
        }
        public string RepeatPassword
        {
            private get => repeatPassword;
            set => SetProperty(ref repeatPassword, Encryption.GetHash(value));
        }

        private RelayCommand registrationCommand;
        private RelayCommand alreadyHaveAnAccountCommand;
        public ICommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                  (registrationCommand = new RelayCommand(
                      (obj) => DoRegistrationCommand(),
                      (obj) => CanExecuteRegistrationCommand()  
                  ));
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
        private void DoRegistrationCommand()
        {
            var error = registrationModel.TryRegistration(Name, Surname, Email, Password, RepeatPassword);
            if (error is null)
            {
                UserMessages.Information("Аккаунт успешно создан");
                var navModel = new NavigationChangedRequestedMessage(new NavigationModel()
                {
                    DestinationVM = new AuthorizationViewModel()
                });
                WeakReferenceMessenger.Default.Send(navModel);
            }
            else
            {
                UserMessages.Error("При создании аккаунта произошла ошибка");
            }
        }
        private bool CanExecuteRegistrationCommand()
        {
            if (new string[] { Name, Surname, Email, Password, RepeatPassword }.Where(x => string.IsNullOrEmpty(x) == true).Any()) return false;
            if (Name.Length > 2 && Surname.Length > 3 && Email.Length > 5 && Password.Length > 5 && RepeatPassword.Length > 5) return true;
            return false;
        }
        public RegistrationViewModel()
        {
            registrationModel = new RegistrationModel();
        }
    }
}
