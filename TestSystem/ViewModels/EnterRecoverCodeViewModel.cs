using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Utilities;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class EnterRecoverCodeViewModel : ObservableObject
    {
        private string code;
        public string Code
        {
            get => code;
            set => SetProperty(ref code, value);
        }
        private RelayCommand nextCommand;
        private RelayCommand authorizationBackCommand;
        public ICommand NextCommand
        {
            get
            {
                return nextCommand ??
                  (nextCommand = new RelayCommand((obj) =>
                  {
                      NavigationMainWindow.Navigate(new ChangePasswordViewModel());
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
        public EnterRecoverCodeViewModel() { }
    }
}
