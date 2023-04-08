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
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new ChangePasswordViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
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
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AuthorizationViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public EnterRecoverCodeViewModel() { }
    }
}
