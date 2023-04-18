using CommunityToolkit.Mvvm.ComponentModel;

namespace TestSystem.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableObject currentVM;
        public ObservableObject CurrentVM
        {
            get => currentVM;
            set => SetProperty(ref currentVM, value);
        }
    }
}
