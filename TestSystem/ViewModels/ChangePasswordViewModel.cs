using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Utilities;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class ChangePasswordViewModel : ObservableObject
    {
        private string password;
        private string repeatPassword;
        public string Password
        {
            private get => password;
            set => SetProperty(ref password, value);
        }
        public string RepeatPassword
        {
            get => repeatPassword;
            set => SetProperty(ref repeatPassword, value);
        }
        private RelayCommand saveCommand;
        private RelayCommand authorizationBackCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand((obj) =>
                  {
                      NavigationMainWindow.Navigate(new AuthorizationViewModel());
                  }));
            }
        }
        public ICommand AuthorizationBackCommand
        {
            get
            {
                return authorizationBackCommand ??
                  (authorizationBackCommand = new RelayCommand((obj) =>
                  {
                      NavigationMainWindow.Navigate(new AuthorizationViewModel());
                  }));
            }
        }
        public ChangePasswordViewModel() { }
    }
}
