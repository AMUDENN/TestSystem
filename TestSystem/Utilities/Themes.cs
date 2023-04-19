using System;
using System.Collections.Generic;
using System.Windows;

namespace TestSystem.Utilities
{
    public class Themes
    {
        public enum ThemesEnum { Light, Dark };
        private static Dictionary<ThemesEnum, string> themesPath = new Dictionary<ThemesEnum, string>()
        {
            { ThemesEnum.Light, @"Resources\Themes\LightTheme.xaml" },
            {ThemesEnum.Dark, @"Resources\Themes\DarkTheme.xaml" }
        };
        public static void ChangeTheme(ThemesEnum theme)
        {
            var uri = new Uri(themesPath[theme], UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            Config.CurrentTheme = theme.ToString();
        }
    }
}
