using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class AbstractMainViewModel : ObservableObject
    {
        private RelayCommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??
                  (backCommand = new RelayCommand(() =>
                  {
                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AuthorizationViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public AbstractMainViewModel()
        {

        }
    }
}
