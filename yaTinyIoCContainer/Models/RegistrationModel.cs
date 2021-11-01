using System;

namespace IoCContainer.Models
{
    internal enum REG_TYPE
    {
        SCOPED,
        SINGLETON,
        TRANSIENT,

    };

    internal class RegistrationModel
    {
        internal Type ObjectType { get; set; }
        internal REG_TYPE RegType { get; set; }
    }
}
