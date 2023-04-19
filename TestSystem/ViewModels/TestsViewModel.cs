using CommunityToolkit.Mvvm.ComponentModel;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class TestsViewModel : ObservableObject
    {
        public UserModel userModel;
        public UserModel UserModel
        {
            private get => userModel;
            set => SetProperty(ref userModel, value);
        }
        public TestsViewModel(UserModel userModel)
        {
            UserModel = userModel;
        }
    }
}
