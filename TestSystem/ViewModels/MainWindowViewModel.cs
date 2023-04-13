using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TestSystem.Models;
using TestSystem.Utilities;

namespace TestSystem.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public UserModel userModel;
        public ObservableObject NavigationVM { get; set; }

        private ObservableObject currentVM;
        public UserModel UserModel
        {
            get => userModel;
            set => SetProperty(ref userModel, value);
        }
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
                          App.GetLoginWindow().Visibility = System.Windows.Visibility.Visible;
                          App.GetMainWindow(UserModel).Visibility = System.Windows.Visibility.Collapsed;
                      }
                  ));
            }
        }
        public MainWindowViewModel(NavigationViewModel navVM)
        {
            NavigationVM = navVM;
            WeakReferenceMessenger.Default.Register<NavigationChangedRequestedMessage>(this, NavigateTo);
        }

        private void NavigateTo(object recipient, NavigationChangedRequestedMessage message)
        {
            if (message.Value is NavigationModel navModel)
                CurrentVM = navModel.DestinationVM;
        }
    }
}
