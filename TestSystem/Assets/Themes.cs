using System;
using System.Windows;

namespace TestSystem.Assets
{
    internal class Themes
    {
        public static void ChangeTheme(string path)
        {
            var uri = new Uri(path, UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as
            ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict); ;
        }
    }
}
