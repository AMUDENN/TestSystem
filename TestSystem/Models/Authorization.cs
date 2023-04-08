using System.Configuration;
using System.Linq;
using TestSystem.Utilities;
using TestSystem.Entities;

namespace TestSystem.Models
{
    public static class Authorization
    {
        public static int GetAuthorization(string email, string password, bool rememberPassword = false)
        {
            TestSystemEntities context = Context.DbContext;
            string hashpassword = Encryption.GetHash(password);
            var user = context.Users.Where(x => x.email == email && x.password == hashpassword);
            if (user.Any() && rememberPassword) SaveEmailAndPassword(email, password);
            return user.Any() ? user.First().id : -1;
        }
        private static void SaveEmailAndPassword(string email, string password)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SaveEmail"].Value = email;
            config.AppSettings.Settings["SavePassword"].Value = password;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static int CheckSaveEmailAndPassword()
        {
            string email = ConfigurationManager.AppSettings.Get("SaveEmail");
            string password = ConfigurationManager.AppSettings.Get("SavePassword");
            if (email.Length < 3 || password.Length < 3) return -1;
            return GetAuthorization(email, password);
        }
    }
}
