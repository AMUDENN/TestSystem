using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace TestSystem.Windows
{
    public partial class MessageBoxWindow : Window
    {
        public enum MessageBoxButton { Ok, OkCancel };
        public enum MessageBoxImage { Info, Error, Question };
        public MessageBoxWindow(string title, string text, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage)
        {
            InitializeComponent();
            Title.Text = title;
            Text.Text = text;
            switch (messageBoxButton)
            {
                case MessageBoxButton.Ok:
                    SetOk();
                    break;
                case MessageBoxButton.OkCancel:
                    SetOkCancel();
                    break;
            }
            SetImageSource(messageBoxImage);
        }
        private void SetOk()
        {
            Ok_Ok.Visibility = Visibility.Visible;
        }
        private void SetOkCancel()
        {
            OkCancel_Ok.Visibility = Visibility.Visible; 
            OkCancel_Cancel.Visibility = Visibility.Visible;
        }
        private void SetImageSource(MessageBoxImage messageBoxImage)
        {
            switch (messageBoxImage)
            {
                case MessageBoxImage.Info:
                    Info.Visibility = Visibility.Visible;
                    break;
                case MessageBoxImage.Error:
                    Error.Visibility = Visibility.Visible;
                    break;
                case MessageBoxImage.Question:
                    Question.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        private void OkClick(object sender, RoutedEventArgs e)
            => DialogResult = true;
        private void CancelClick(object sender, RoutedEventArgs e)
            => DialogResult = false;
    }
}
