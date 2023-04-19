using System;
using System.Linq;
using TestSystem.Entities;
using TestSystem.Utilities;

namespace TestSystem.Models
{
    public class UserModel
    {
        public Users CurrentUser { get; set; }
        public Exception TryAuthorization(string email, string password, bool rememberPassword = false)
        {
            var context = Context.GetContext();
            var user = context.Users.FirstOrDefault(x => x.email == email);
            if (user is null) return new Exception("Нет аккаунта с таким адресом эл.почты");
            if (user.password != Encryption.GetHash(password)) return new Exception("Неверный пароль");
            //ДОБАВИТЬ ПОЛЕ В БД С ПРОВЕРКОЙ ПОДТВЕРЖДЁННОСТИ email
            //if (!user.IsConfirmed) return new Exception("Эл.почта не подтверждена");
            CurrentUser = user;
            if (rememberPassword) SaveLoginInConfig(email, password);
            return null;
        }
        private void SaveLoginInConfig(string email, string password)
        {
            Config.SaveEmail = email;
            Config.SavePassword = password;
        }
        public Exception TryConfigAuthorization()
        {
            string email = Config.SaveEmail;
            string password = Config.SavePassword;

            Exception error = TryAuthorization(email, password);

            return error is null ? error : new Exception("Сохранённые данные неверны");
        }
        public void LogOut()
        {
            Config.SaveEmail = "";
            Config.SavePassword = "";
        }
    }
}
