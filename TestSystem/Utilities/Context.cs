using TestSystem.Entities;

namespace TestSystem.Utilities
{
    public static class Context
    {
        private static TestSystemEntities DbContext = new TestSystemEntities();
        public static TestSystemEntities GetContext() => DbContext;
    }
}
