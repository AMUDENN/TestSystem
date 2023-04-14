using System;
using ToastNotifications.Core;

namespace TestSystem.Utilities
{
    public static class ToastNotification
    {
        private static ToastViewModel toastViewModel;
        public static ToastViewModel ToastViewModel => toastViewModel;
        public static void ShowMessage(Action<string, MessageOptions> action, string name)
        {
            MessageOptions opts = new MessageOptions
            {
                ShowCloseButton = true
            };
            action(name, opts);
        }
        public static void Reset()
        {
            toastViewModel = new ToastViewModel();
        }
        static ToastNotification()
        {
            Reset();
        }
    }
}
