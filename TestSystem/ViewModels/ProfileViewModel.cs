using CommunityToolkit.Mvvm.ComponentModel;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class ProfileViewModel : ObservableObject
    {
        public UserModel userModel;
        public UserModel UserModel
        {
            private get => userModel;
            set => SetProperty(ref userModel, value);
        }
        public string Name => userModel.CurrentUser.name;
        public string Surname => userModel.CurrentUser.surname;
        public string Patronymic => userModel.CurrentUser.patronymic;
        public string Email => userModel.CurrentUser.email;
        public ProfileViewModel(UserModel userModel)
        {
            UserModel = userModel;
        }
    }
}
