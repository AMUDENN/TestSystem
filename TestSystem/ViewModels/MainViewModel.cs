using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Net;
using System.Windows.Input;
using TestSystem.Models;
using TestSystem.Utilities;

namespace TestSystem.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public UserModel userModel;
        public ObservableObject NavigationVM { get; set; }

        private ObservableObject currentVM;
        public UserModel UserModel
        {
            get => userModel;
            set => SetProperty(ref userModel, value);
        }
        public string Name => userModel.CurrentUser.name;
        public string Surname => userModel.CurrentUser.surname;
        public ObservableObject CurrentVM
        {
            get => currentVM;
            set => SetProperty(ref currentVM, value);
        }
        private RelayCommand logOut;
        public ICommand LogOut
        {
            get
            {
                return logOut ??
                  (logOut = new RelayCommand((obj) =>
                      {
                          userModel.LogOut();
                          NavigationMainWindow.Navigate(new AuthorizationViewModel());
                      }
                  ));
            }
        }
        public MainViewModel(UserModel userModel)
        {
            UserModel = userModel;
            NavigationVM = new NavigationViewModel(userModel);
            WeakReferenceMessenger.Default.Register<NavigationChangedRequestedMessage>(this, NavigateTo);
        }

        private void NavigateTo(object recipient, NavigationChangedRequestedMessage message)
        {
            if (message.Value is NavigationModel navModel)
                CurrentVM = navModel.DestinationVM;
        }
    }
}
