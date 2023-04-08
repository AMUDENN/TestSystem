using System.ComponentModel;
using System.Configuration;
using System.Windows;
using static TestSystem.Utilities.Themes;

namespace TestSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += ShowCloseMessage;
        }
        private void ShowCloseMessage(object sender, CancelEventArgs e)
        {
            if (!Utilities.UserMessages.ActionConfirmation("Вы уверены, что хотите закрыть приложение?")) e.Cancel = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string theme = ConfigurationManager.AppSettings.Get("CurrentTheme");
            if (theme == "Light")
            {
                MainWindowStyle.WindowStyle.ChangeDefaultTheme(ThemesEnum.Light);
            }
            else if (theme == "Dark")
            {
                MainWindowStyle.WindowStyle.ChangeDefaultTheme(ThemesEnum.Dark);
            }
        }
    }
}
