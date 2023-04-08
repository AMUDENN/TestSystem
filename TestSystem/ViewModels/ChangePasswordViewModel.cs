using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class ChangePasswordViewModel : ObservableObject
    {
        private string password;
        private string repeatPassword;
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
        private RelayCommand saveCommand;
        private RelayCommand authorizationBackCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(() =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AuthorizationViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public ICommand AuthorizationBackCommand
        {
            get
            {
                return authorizationBackCommand ??
                  (authorizationBackCommand = new RelayCommand(() =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AuthorizationViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public ChangePasswordViewModel() { }
    }
}
