using System;
using System.Windows;
using System.Windows.Controls;

namespace TestSystem.Resources.Styles
{
    public partial class PasswordBoxStyles
    {
        private void PasswordChangedHandler(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            Label lbl = pb.Template.FindName("WaterMarkLabel", pb) as Label;
            lbl.Visibility = pb.Password == String.Empty ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
