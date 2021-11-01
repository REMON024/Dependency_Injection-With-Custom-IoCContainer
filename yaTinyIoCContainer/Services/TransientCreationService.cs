using System;

namespace IoCContainer.Services
{
    internal class TransientCreationService
    {
        static TransientCreationService instance = null;

        static TransientCreationService()
        {
            instance = new TransientCreationService();
        }

        private TransientCreationService()
        { }

        public static TransientCreationService GetInstance()
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
