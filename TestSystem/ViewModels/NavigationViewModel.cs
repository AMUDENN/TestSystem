using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class NavigationViewModel : ObservableObject
    {
        public List<NavigationModel> NavigationOptions { get; set; } = new List<NavigationModel>();

        public ICommand SelectionChangedCommand { get; set; } = new RelayCommand<object>((o) =>
        {
            if (o is SelectionChangedEventArgs selectionChanged)
            {
                if (selectionChanged.AddedItems.Count == 0)
                    return;
                if (selectionChanged.AddedItems[0] is NavigationModel navModel)
                {
                    var message = new NavigationChangedRequestedMessage(navModel);
                    WeakReferenceMessenger.Default.Send(message);
                }
            }
        });

        public NavigationViewModel(
            AuthorizationViewModel authorizationView,
            RegistrationViewModel registrationView,
            RecoverPasswordViewModel recoverPasswordView,
            EnterRecoverCodeViewModel enterRecoverCodeView,
            ChangePasswordViewModel changePasswordView)
        {

            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Главная",
                ImageSource = @"/Resources/Images/HomeListVIew.svg",
                DestinationVM = authorizationView
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Профиль",
                ImageSource = @"/Resources/Images/ProfileListVIew.svg",
                DestinationVM = registrationView
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Тесты",
                ImageSource = @"/Resources/Images/TestsListVIew.svg",
                DestinationVM = recoverPasswordView
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Результаты",
                ImageSource = @"/Resources/Images/ResultsListVIew.svg",
                DestinationVM = enterRecoverCodeView
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Настройки",
                ImageSource = @"/Resources/Images/SettingsListVIew.svg",
                DestinationVM = changePasswordView
            });

            var message = new NavigationChangedRequestedMessage(NavigationOptions[0]);
            WeakReferenceMessenger.Default.Send(message);
        }
    }
}
