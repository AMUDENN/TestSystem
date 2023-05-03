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
        private UserModel currentUser;
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

        public NavigationViewModel(UserModel currentUser)
        {
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Главная",
                ImageSource = @"/Resources/Images/Vectors/HomeListView.svg",
                DestinationVM = new HomeViewModel(currentUser)
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Профиль",
                ImageSource = @"/Resources/Images/Vectors/ProfileListVIew.svg",
                DestinationVM = new ProfileViewModel(currentUser)
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Тесты",
                ImageSource = @"/Resources/Images/Vectors/TestsListVIew.svg",
                DestinationVM = new TestsViewModel(currentUser)
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Результаты",
                ImageSource = @"/Resources/Images/Vectors/ResultsListVIew.svg",
                DestinationVM = new ResultsViewModel(currentUser)
            });
            NavigationOptions.Add(new NavigationModel()
            {
                Name = "Настройки",
                ImageSource = @"/Resources/Images/Vectors/SettingsListVIew.svg",
                DestinationVM = new SettingsViewModel(currentUser)
            });

            var message = new NavigationChangedRequestedMessage(NavigationOptions[0]);
            WeakReferenceMessenger.Default.Send(message);
            this.currentUser = currentUser;
        }
    }
}
