using TestSystem.Entities;

namespace TestSystem.Utilities
{
    public static class Context
    {
        private static TestSystemEntities DbContext;
        public static TestSystemEntities GetContext()
        {
            if (DbContext == null)
                DbContext = new TestSystemEntities();
            return DbContext;
        }
    }
}
