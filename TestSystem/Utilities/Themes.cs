using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;

namespace TestSystem.Utilities
{
    public class Themes
    {
        public enum ThemesEnum { Light, Dark };
        private static Dictionary<ThemesEnum, string> themesPath = new Dictionary<ThemesEnum, string>()
        {
            { ThemesEnum.Light, "Resources\\Dictionaries\\LightTheme.xaml" },
            {ThemesEnum.Dark, "Resources\\Dictionaries\\DarkTheme.xaml" } 
        };
        public static void ChangeTheme(ThemesEnum theme)
        {
            var uri = new Uri(themesPath[theme], UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["CurrentTheme"].Value = theme.ToString();
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
