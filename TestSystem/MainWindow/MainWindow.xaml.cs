using System;
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
            if (ActionConfirmation("Вы уверены, что хотите закрыть приложение?") == MessageBoxResult.No) e.Cancel = true;
        }
        private static MessageBoxResult ActionConfirmation(string question) => MessageBox.Show(question, "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
    }
}
