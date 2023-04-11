using System.ComponentModel;
using System.Configuration;
using System.Windows;
using static TestSystem.Utilities.Themes;

namespace TestSystem
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Closing += ShowCloseMessage;
        }
        public void ShowCloseMessage(object sender, CancelEventArgs e)
        {
            if (!Utilities.UserMessages.ActionConfirmation("Вы уверены, что хотите закрыть приложение?")) e.Cancel = true;
        }
    }
}
