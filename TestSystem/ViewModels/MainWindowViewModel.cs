using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TestSystem.Models;

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
