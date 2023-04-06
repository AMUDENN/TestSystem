using System;
using System.Windows;
using System.Windows.Controls;

namespace MainWindowStyle
{
    public partial class WindowStyle
    {
        public enum Themes { Light, Dark };
        public static void ChangeDefaultTheme(Themes theme)
        {
            Window me = Application.Current.MainWindow;
            CheckBox cb = me.Template.FindName("ChangeThemeCheckBox", me) as CheckBox;
            cb.IsChecked = theme != Themes.Light;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as System.Windows.Window).StateChanged += Window_StateChanged;
        }
        private void Window_StateChanged(object sender, EventArgs e)
        {
            System.Windows.Window me = (sender as System.Windows.Window);
            Button maximizeCaptionButton = me.Template.FindName("MaxRestoreButton", me) as Button;
            if (maximizeCaptionButton != null)
            {
                maximizeCaptionButton.Content = me.WindowState == WindowState.Maximized ? "2" : "1";
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            ((sender as FrameworkElement).TemplatedParent as System.Windows.Window).Close();
        }
        private void MaxRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            ((sender as FrameworkElement).TemplatedParent as System.Windows.Window)
                .WindowState = (((sender as FrameworkElement).TemplatedParent as System.Windows.Window)
                .WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            ((sender as FrameworkElement).TemplatedParent as System.Windows.Window)
                .WindowState = WindowState.Minimized;
        }
        private void ToggleSwitchChecked(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources\\Dictionaries\\DarkTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as
            ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        private void ToggleSwitchUnchecked(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources\\Dictionaries\\LightTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as
            ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict); ;
        }
    }
}
