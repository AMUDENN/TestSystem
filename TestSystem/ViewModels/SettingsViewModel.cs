using CommunityToolkit.Mvvm.ComponentModel;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class SettingsViewModel : ObservableObject
    {
        public UserModel userModel;
        public UserModel UserModel
        {
            private get => userModel;
            set => SetProperty(ref userModel, value);
        }
        public SettingsViewModel(UserModel userModel)
        {
            UserModel = userModel;
        }
    }
}
