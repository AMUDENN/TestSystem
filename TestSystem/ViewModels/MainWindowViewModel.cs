using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Threading;
using System.Windows;
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
                          ToastNotification.ToastViewModel.ClearAll();
                          ToastNotification.Reset();
                          Window mw = App.GetLoginWindow();
                          mw.Show();
                          App.Current.MainWindow.Closing -= MainWindowStyle.WindowStyle.ShowCloseMessage;
                          App.Current.MainWindow.Close();
                          App.Current.MainWindow = mw;
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
