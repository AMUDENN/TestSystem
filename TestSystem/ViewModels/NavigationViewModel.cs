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

        public NavigationViewModel()
        {

            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Главная",
                ImageSource = @"/Resources/Images/HomeListView.svg",
                DestinationVM = new HomeViewModel()
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Профиль",
                ImageSource = @"/Resources/Images/ProfileListVIew.svg",
                DestinationVM = new RegistrationViewModel()
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Тесты",
                ImageSource = @"/Resources/Images/TestsListVIew.svg",
                DestinationVM = new RecoverPasswordViewModel()
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Результаты",
                ImageSource = @"/Resources/Images/ResultsListVIew.svg",
                DestinationVM = new EnterRecoverCodeViewModel()
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Настройки",
                ImageSource = @"/Resources/Images/SettingsListVIew.svg",
                DestinationVM = new ChangePasswordViewModel()
            });

            var message = new NavigationChangedRequestedMessage(NavigationOptions[0]);
            WeakReferenceMessenger.Default.Send(message);
        }
    }
}
