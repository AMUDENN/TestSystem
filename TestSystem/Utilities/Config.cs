using System.Configuration;

namespace TestSystem.Utilities
{
    public static class Config
    {
        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public static string CurrentTheme
        {
            get => config.AppSettings.Settings["CurrentTheme"].Value;
            set => SaveProperty("CurrentTheme", value);
        }
        public static string SaveEmail
        {
            get => config.AppSettings.Settings["SaveEmail"].Value;
            set => SaveProperty("SaveEmail", value);
        }
        public static string SavePassword
        {
            get => config.AppSettings.Settings["SavePassword"].Value;
            set => SaveProperty("SavePassword", value);
        }
        private static void SaveProperty(string name, string value)
        {
            config.AppSettings.Settings[name].Value = value;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
