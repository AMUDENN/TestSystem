using System.ComponentModel;
using System.Windows;

namespace TestSystem.MainWindows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
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
