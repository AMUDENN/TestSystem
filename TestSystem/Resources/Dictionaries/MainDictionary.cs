using System;
using System.Windows;
using System.Windows.Controls;

namespace TestSystem.Resources.Dictionaries
{
    public partial class MainDictionary
    {
        private void PasswordChangedHandler(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            Label lbl = pb.Template.FindName("WaterMarkLabel", pb) as Label;
            lbl.Visibility = pb.Password == String.Empty ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
