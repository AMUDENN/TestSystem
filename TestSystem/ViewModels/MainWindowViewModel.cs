using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public ObservableObject NavigationVM { get; set; }

        private ObservableObject currentVM;

        public ObservableObject CurrentVM
        {
            get => currentVM;
            set => SetProperty(ref currentVM, value);
        }

        public MainWindowViewModel(NavigationViewModel navVM)
        {
            NavigationVM = navVM;            
            WeakReferenceMessenger.Default.Register<NavigationChangedRequestedMessage>(this, NavigateTo);


            //логика дефолтной страницы
            if (Authorization.CheckSaveEmailAndPassword() == -1)
            {
                var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AuthorizationViewModel() });
                WeakReferenceMessenger.Default.Send(navModel);
            }
            else
            {
                var navModel = new NavigationChangedRequestedMessage(new NavigationModel() { DestinationVM = new AbstractMainViewModel() });
                WeakReferenceMessenger.Default.Send(navModel);
            }
        }

        private void NavigateTo(object recipient, NavigationChangedRequestedMessage message)
        {
            if (message.Value is NavigationModel navModel)
                CurrentVM = navModel.DestinationVM;
        }
    }
}
