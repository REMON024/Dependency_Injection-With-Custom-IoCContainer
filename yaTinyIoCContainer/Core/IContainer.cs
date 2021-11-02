namespace IoCContainer.Core
{
    public interface IContainer
    {
        void RegisterInstanceType<I, C>()
            where I : class
            where C : class;

        void RegisterTransientType<I, C>()
            where I : class
            where C : class;

        void RegisterSingletonType<I, C>()
            where I : class
            where C : class;

        T Resolve<T>();

        void clearScopedPull();
    }
}
