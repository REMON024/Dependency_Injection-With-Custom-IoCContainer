using System;
using System.Collections.Generic;

namespace IoCContainer.Services
{
    internal class ScopedCreationService
    {
        static ScopedCreationService instance = null;
        static Dictionary<string, object> objectPools = new Dictionary<string, object>();


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
                if (objectPools.ContainsKey(t.Name) == false)
                {
                    obj = Activator.CreateInstance(t, arguments);
                    //obj = TransientCreationService.GetInstance().GetNewObject(t, arguments);

                    objectPools.Add(t.Name, obj);
                }
                else
                {
                    obj = objectPools[t.Name];
                }

                //obj = TransientCreationService.GetInstance().GetNewObject(t, arguments);
                //objectPools.Add(t.Name, obj);
            }
            catch
            {

            }

            return obj;
        }

        public void clearObjectPull()
        {
            objectPools = new Dictionary<string, object>();
        }
    }
}
