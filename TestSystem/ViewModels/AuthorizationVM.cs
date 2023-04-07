using TestSystem.Assets;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestSystem.ViewModels
{
    class AuthorizationVM : INotifyPropertyChanged
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
            get { return password; }
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
        public RelayCommand SingInCommand
        {
            get
            {
                return singInCommand ??
                    (singInCommand = new RelayCommand(obj =>
                    {
                        UserMessages.ActionConfirmation(email);
                    }));
            }
        }
        private RelayCommand registrationCommand;
        public RelayCommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                    (registrationCommand = new RelayCommand(obj =>
                    {
                        UserMessages.ActionConfirmation(email);
                    }));
            }
        }
        private RelayCommand forgotPasswordCommand;
        public RelayCommand ForgotPasswordCommand
        {
            get
            {
                return singInCommand ??
                    (singInCommand = new RelayCommand(obj =>
                    {
                        UserMessages.ActionConfirmation(email);
                    }));
            }
        }
        public AuthorizationVM()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
