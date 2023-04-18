using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Utilities;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class RecoverPasswordViewModel : ObservableObject
    {
        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        private RelayCommand getCodeCommand;
        private RelayCommand authorizationBackCommand;
        public ICommand GetCodeCommand
        {
            get
            {
                return getCodeCommand ??
                  (getCodeCommand = new RelayCommand((obj) =>
                  {
                      NavigationMainWindow.Navigate(new EnterRecoverCodeViewModel());
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
        public RecoverPasswordViewModel() { }
    }
}
