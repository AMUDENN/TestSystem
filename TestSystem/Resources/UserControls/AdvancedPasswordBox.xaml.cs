using System;
using System.Windows;
using System.Windows.Controls;

namespace TestSystem.Resources.UserControls
{
    public partial class AdvancedPasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            name: "Password", propertyType: typeof(String), ownerType: typeof(AdvancedPasswordBox)
		);
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(
            name: "Placeholder", propertyType: typeof(String), ownerType: typeof(AdvancedPasswordBox)
        );
        public string Password
        {
            get => (string)GetValue(dp: PasswordProperty);
            set => SetValue(dp: PasswordProperty, value: value);
        }
        public string Placeholder
        {
            get => (string)GetValue(dp: PlaceholderProperty);
            set => SetValue(dp: PlaceholderProperty, value: value);
        }
        public AdvancedPasswordBox()
        {
            InitializeComponent();
        }
        private void PasswordChangedHandler(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            Password = pb.Password;
        }

        private void ViewPasswordButtonPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainTextBox.Visibility = Visibility.Visible;
            Eye.Visibility = Visibility.Visible;
            MainTextBox.Text = Password;
            MainPasswordBox.Visibility = Visibility.Collapsed;
            OffEye.Visibility = Visibility.Collapsed;
        }

        private void ViewPasswordButtonPreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainTextBox.Visibility = Visibility.Collapsed;
            Eye.Visibility = Visibility.Collapsed;
            MainPasswordBox.Visibility = Visibility.Visible;
            OffEye.Visibility = Visibility.Visible;
        }
    }
}
