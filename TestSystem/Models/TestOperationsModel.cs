using System;
using System.Collections.Generic;
using System.Linq;
using TestSystem.Entities;
using TestSystem.Utilities;

namespace TestSystem.Models
{
    public class TestOperationsModel
    {
        private UserModel userModel;
        public TestOperationsModel(UserModel userModel)
        {
            this.userModel = userModel;
        }
        public IEnumerable<TestModel> GetTestModels() => userModel.CurrentUser.Tests.Select(x => new TestModel(x));
        public TestModel AddTest(string testTitle = "Новый тест", bool testIsOrdered = false)
        {
            TestModel testModel = null;
            try
            {
                Tests test = new Tests()
                {
                    teacher_id = userModel.CurrentUser.id,
                    title = testTitle,
                    is_ordered = testIsOrdered,
                    date_creation = DateTime.Now
                };
                var context = Context.GetContext();
                context.Tests.Add(test);
                context.SaveChanges();
                testModel = new TestModel(test);
            }
            catch
            {
                return null;
            }
            return testModel;
        }
    }
}
