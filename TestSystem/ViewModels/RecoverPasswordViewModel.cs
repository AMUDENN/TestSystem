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
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new EnterRecoverCodeViewModel() });
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
        public RecoverPasswordViewModel() { }
    }
}
