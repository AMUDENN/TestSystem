using CommunityToolkit.Mvvm.ComponentModel;
using TestSystem.Models;

namespace TestSystem.ViewModels
{
    public class ResultsViewModel : ObservableObject
    {
        public UserModel userModel;
        public UserModel UserModel
        {
            private get => userModel;
            set => SetProperty(ref userModel, value);
        }
        public ResultsViewModel(UserModel userModel)
        {
            UserModel = userModel;
        }
    }
}
