using System;

namespace IoCContainer.Services
{
    internal class ScopedCreationService
    {
        static ScopedCreationService instance = null;

        static ScopedCreationService()
        {
            instance = new ScopedCreationService();
        }

        private ScopedCreationService()
        { }

        public static ScopedCreationService GetInstance()
        {
            return instance;
        }

        public object GetNewObject(Type t, object[] arguments = null)
        {
            object obj = null;

            try
            {
                obj = Activator.CreateInstance(t, arguments);
            }
            catch
            {
                // log it maybe
            }

            return obj;
        }
    }
}
