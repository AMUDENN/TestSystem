using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TestSystem.Assets
{
    class Navigation
    {
        public static void ChangePage(Page page)
        {
            MainWindow mw = MainWindow.Instance;
            Frame frame = mw.Template.FindName("MainFrame", mw) as Frame;
            frame.Navigate(page);
        }
    }
}
