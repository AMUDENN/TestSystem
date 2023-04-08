using TestSystem.Windows;

namespace TestSystem.Utilities
{
    internal class UserMessages
    {
        public static bool ActionConfirmation(string question)
           => (bool)new MessageBoxWindow("Подтверждение", question, MessageBoxWindow.MessageBoxButton.OkCancel, MessageBoxWindow.MessageBoxImage.Question).ShowDialog();
        public static bool Information(string info)
            => (bool)new MessageBoxWindow("Уведомление", info, MessageBoxWindow.MessageBoxButton.Ok, MessageBoxWindow.MessageBoxImage.Info).ShowDialog();
        public static bool Error(string text)
            => (bool)new MessageBoxWindow("Ошибка", text, MessageBoxWindow.MessageBoxButton.Ok, MessageBoxWindow.MessageBoxImage.Error).ShowDialog();
    }
}
