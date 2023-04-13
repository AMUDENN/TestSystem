using System;
using System.Windows;
using System.Windows.Controls;
using TestSystem.Utilities;

namespace MainWindowStyle
{
    public partial class WindowStyle
    {
        private void ChangeDefaultTheme(Themes.ThemesEnum theme, Window window)
        {
            CheckBox cb = window.Template.FindName("ChangeThemeCheckBox", window) as CheckBox;
            cb.IsChecked = theme != Themes.ThemesEnum.Light;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Window wdw = sender as System.Windows.Window;
            wdw.StateChanged += Window_StateChanged;
            wdw.MaxHeight = System.Windows.SystemParameters.WorkArea.Height + 7;
            wdw.MaxWidth = System.Windows.SystemParameters.WorkArea.Width + 7;
            if (Config.CurrentTheme == "Light")
            {
                ChangeDefaultTheme(Themes.ThemesEnum.Light, wdw);
            }
            else if (Config.CurrentTheme == "Dark")
            {
                ChangeDefaultTheme(Themes.ThemesEnum.Dark, wdw);
            }
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
            Themes.ChangeTheme(Themes.ThemesEnum.Dark);
        }
        private void ToggleSwitchUnchecked(object sender, RoutedEventArgs e)
        {
            Themes.ChangeTheme(Themes.ThemesEnum.Light);
        }
    }
}
