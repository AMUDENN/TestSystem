using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class AbstractMainViewModel : ObservableObject
    {
        private UserModel userModel;
        private RelayCommand backCommand;
        public UserModel UserModel { get; set; }
        public string Name => userModel.CurrentUser.name;

        public ICommand BackCommand
        {
            get
            {
                return backCommand ??
                  (backCommand = new RelayCommand(() =>
                  {
                      userModel.LogOut();

                      var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AuthorizationViewModel() });
                      WeakReferenceMessenger.Default.Send(navModel);
                  }));
            }
        }
        public AbstractMainViewModel(UserModel userModel)
        {
            this.userModel = userModel; 
        }
    }
}
