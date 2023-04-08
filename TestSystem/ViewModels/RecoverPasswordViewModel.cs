using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class RecoverPasswordViewModel : ObservableObject
    {
        private string email;
        public string Email
        {
            private get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        private RelayCommand getCodeCommand;
        private RelayCommand authorizationBackCommand;
        public ICommand GetCodeCommand
        {
            get
            {
                return getCodeCommand ??
                  (getCodeCommand = new RelayCommand(() =>
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
                  (authorizationBackCommand = new RelayCommand(() =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AuthorizationViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public RecoverPasswordViewModel() { }
    }
}
