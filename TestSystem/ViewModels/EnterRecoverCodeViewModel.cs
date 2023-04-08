using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class EnterRecoverCodeViewModel : ObservableObject
    {
        private string code;
        public string Code
        {
            private get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }
        private RelayCommand nextCommand;
        private RelayCommand authorizationBackCommand;
        public ICommand NextCommand
        {
            get
            {
                return nextCommand ??
                  (nextCommand = new RelayCommand(() =>
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
                  (authorizationBackCommand = new RelayCommand(() =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AuthorizationViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public EnterRecoverCodeViewModel() { }
    }
}
