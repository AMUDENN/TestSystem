using System;
using System.Linq;
using TestSystem.Entities;
using TestSystem.Utilities;

namespace TestSystem.Models
{
    class RegistrationModel
    {
        public Exception TryRegistration(string name, string surname, string email, string password, string confirmpassword)
        {
            if (password != confirmpassword) return new Exception("Пароли не соввпадают");
            var context = Context.DbContext;
            if (context.Users.FirstOrDefault(x => x.email == email) != null) return new Exception("Аккаунт с этим адресом эл. почты уже существует");
            try
            {
                context.Users.Add
                    (
                        new Users()
                        {
                            name = name,
                            surname = surname,
                            email = email,
                            password = password
                        }
                    );
                context.SaveChanges();
            }
            catch
            {
                return new Exception("Произошла ошибка при сохранении данных, попробуйте позже");
            }
            return null;
        }
    }
}
