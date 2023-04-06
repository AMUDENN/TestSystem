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
        readonly Style LightMainColorButtonStyle = (Style)Application.Current.Resources["LightMainColorButtonStyle"];
        readonly Style DarkMainColorButtonStyle = (Style)Application.Current.Resources["DarkMainColorButtonStyle"];
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
            Button ok = new Button()
            {
                Style = LightMainColorButtonStyle,
                FontSize = 14,
                Content = "Ок",
                Margin = new Thickness(3)
            };
            ok.Click += OkClick;
            Grid.SetRow(ok, 1);
            Grid.SetColumn(ok, 3);
            MainGrid.Children.Add(ok);
        }
        private void SetOkCancel()
        {
            Button ok = new Button()
            {
                Style = LightMainColorButtonStyle,
                FontSize = 14,
                Content = "Ок",
                Margin = new Thickness(3)
            };
            ok.Click += OkClick;
            Grid.SetRow(ok, 1);
            Grid.SetColumn(ok, 2);
            MainGrid.Children.Add(ok);

            Button cancel = new Button()
            {
                Style = DarkMainColorButtonStyle,
                FontSize = 14,
                Content = "Отмена",
                Margin = new Thickness(3)
            };
            cancel.Click += CancelClick;
            Grid.SetRow(cancel, 1);
            Grid.SetColumn(cancel, 3);
            MainGrid.Children.Add(cancel);
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
