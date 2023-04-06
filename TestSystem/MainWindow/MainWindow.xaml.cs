using System.ComponentModel;
using System.Windows;
using TestSystem.Pages;

namespace TestSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += ShowCloseMessage;

            MainFrame.Content = new AuthorizationPage();
            //MainFrame.Content = new RegistrationPage();
            //MainFrame.Content = new RecoverPasswordPage();
            //MainFrame.Content = new EnterRecoverCodePage();
            //MainFrame.Content = new ChangePasswordPage();
        }
        private void ShowCloseMessage(object sender, CancelEventArgs e)
        {
            if (!UserMessages.ActionConfirmation("Вы уверены, что хотите закрыть приложение?")) e.Cancel = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Какая-то логика загрузки дефолтного стиля
            MainWindowStyle.WindowStyle.ChangeDefaultTheme(MainWindowStyle.WindowStyle.Themes.Dark);
        }
    }
}
