using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class LoginWindowViewModel : ObservableObject
    {
        private bool isVisible = true;
        private ObservableObject currentVM;
        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }
        public ObservableObject CurrentVM
        {
            get => currentVM;
            set => SetProperty(ref currentVM, value);
        }
        public LoginWindowViewModel()
        {
            WeakReferenceMessenger.Default.Register<NavigationChangedRequestedMessage>(this, NavigateTo);
            var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AuthorizationViewModel() });
            WeakReferenceMessenger.Default.Send(navModel);
        }
        private void NavigateTo(object recipient, NavigationChangedRequestedMessage message)
        {
            if (message.Value is NavigationModel navModel)
                CurrentVM = navModel.DestinationVM;
        }
    }
}
