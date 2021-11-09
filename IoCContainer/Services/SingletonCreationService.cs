using System;
using System.Collections.Generic;

namespace IoCContainer.Services
{
    internal class SingletonCreationService
    {
        static SingletonCreationService instance = null;
        static Dictionary<string, object> objectPool = new Dictionary<string, object>();

        static SingletonCreationService()
        {
            instance = new SingletonCreationService();
        }

        private SingletonCreationService()
        { }

        public static SingletonCreationService GetInstance()
        {
            return instance;
        }

        public object GetSingleton(Type t, object[] arguments = null)
        {
            object obj = null;

            try
            {
                if (objectPool.ContainsKey(t.Name) == false)
                {
                    obj = ScopedCreationService.GetInstance().GetNewObject(t, arguments);
                    //obj = Activator.CreateInstance(t, arguments);

                    objectPool.Add(t.Name, obj);
                }
                else
                {
                    obj = objectPool[t.Name];
                }
            }
            catch
            {
                // log it maybe
            }


            return obj;
        }
    }
}
