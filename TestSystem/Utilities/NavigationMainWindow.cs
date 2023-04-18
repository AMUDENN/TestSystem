using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using TestSystem.ViewModels;

namespace TestSystem.Utilities
{
    public static class NavigationMainWindow
    {
        public static void Navigate(ObservableObject VM)
        {
            MainWindowViewModel MainVM = App.Container.GetService<MainWindowViewModel>() as MainWindowViewModel;
            MainVM.CurrentVM = VM;
        }
    }
}
