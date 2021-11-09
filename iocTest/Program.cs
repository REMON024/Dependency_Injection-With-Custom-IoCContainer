using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IoCContainer.Attributes;
using IoCContainer.Core;

namespace iocTest
{
    interface ITest1
    {
        void Print();
    }

    class ClassTest1 : ITest1
    {
        public void Print()
        {
            Console.WriteLine("ClassName: {0}, HashCode: {1}, Type: Scoped", this.GetType().Name, this.GetHashCode());
        }
    }

    interface ITest2
    {
        void Print();
    }

    class ClassTest2 : ITest2
    {
        public void Print()
        {
            Console.WriteLine("ClassName: {0}, HashCode: {1}, Type: Singleton", this.GetType().Name, this.GetHashCode());
        }
    }

    interface IOne
    {
        void FunctionOne();
    }

    interface ITwo
    {
        void FunctionTwo();
    }
    interface IThree
    {
        void FunctionThree();
    }

    class ClassOne : IOne
    {
        ITest1 m_Itest1 = null;
        

        [Dependency]
        public ClassOne(ITest1 test1)
        {
            m_Itest1 = test1;
            
        }

        public void FunctionOne()
        {
            Console.WriteLine("ClassName: {0}, HashCode: {1}, Type: Scoped", this.GetType().Name, this.GetHashCode());

            m_Itest1.Print();
            

        }
    }

    class ClassTwo : ITwo
    {
        IOne m_One = null;
        IThree m_Three = null;
        ITest2 m_Itest2 = null;

        [Dependency]
        public ClassTwo(ITest2 test2, IOne one
            , IThree three
            )
        {
            m_Itest2 = test2;
            m_One = one;
            m_Three = three;
        }


        public void FunctionTwo()
        {
            Console.WriteLine("ClassName: {0}, HashCode: {1}, Type: Scoped", this.GetType().Name, this.GetHashCode());

            m_Itest2.Print();
            m_One.FunctionOne();
            m_Three.FunctionThree();
        }
    }

    class ClassThree : IThree
    {

        [Dependency]
        public ClassThree()
        {

        }

        public void FunctionThree()
        {
            var res = this.GetHashCode();
            Console.WriteLine("ClassName: {0}, HashCode: {1}, Type: Transient", this.GetType().Name, this.GetHashCode());


        }
    }

    interface IDemoMessage
    {
        void ShowMessage();
    }

    class Message1 : IDemoMessage
    {
        private  readonly  DateTime dateTime;
        public Message1()
        {
            dateTime = DateTime.Now;

        }
        public void ShowMessage()
        {
            Console.WriteLine("Hello from Message 1 Date Time: {0}", dateTime);

        }
    }
    class Message2 : IDemoMessage
    {
        public void ShowMessage()
        {
            Console.WriteLine("Hello from Message 2");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var count = 1;
            IContainer container = new IoCContainer.Container();


            container.RegisterScopeType<ITest1, ClassTest1>();
            container.RegisterSingletonType<ITest2, ClassTest2>();
            container.RegisterTransientType<IThree, ClassThree>();
            container.RegisterScopeType<IDemoMessage, Message1>();
            container.RegisterScopeType<IDemoMessage, Message2>();
            container.RegisterScopeType<IOne, ClassOne>();
            container.RegisterScopeType<ITwo, ClassTwo>();
            IDemoMessage obj1 = container.Resolve<IDemoMessage>();
            obj1.ShowMessage();
            Thread.Sleep(1000);
            IDemoMessage obj2 = container.Resolve<IDemoMessage>();
            obj2.ShowMessage();

            //while (count > 0)
            //{
            //    // testing scope type resigtration for class
            //    Console.WriteLine();
            //    Console.WriteLine("testing scope type resigtration for class");
            //    ITest1 obj1 = container.Resolve<ITest1>();
            //    obj1.Print();


            //    // testing singleton registration for class
            //    Console.WriteLine();
            //    Console.WriteLine("testing singleton registration for class");
            //    ITest2 obj5 = container.Resolve<ITest2>();
            //    obj5.Print();


            //    // testing Transient type resigtration for class
            //    Console.WriteLine();
            //    Console.WriteLine("testing Transient type resigtration for class");
            //    IThree obj11 = container.Resolve<IThree>();
            //    obj11.FunctionThree();


            //    // testing nested dependency for 2 levels
            //    Console.WriteLine();
            //    Console.WriteLine("testing scope type with nested dependency for 2 levels");
            //    IOne obj9 = container.Resolve<IOne>();
            //    obj9.FunctionOne();


            //    //testing nested dependency for 2 levels with 2 arguments
            //    Console.WriteLine();
            //    Console.WriteLine("testing scope type with nested dependency for 2 levels with 2 arguments");
            //    ITwo obj10 = container.Resolve<ITwo>();
            //    obj10.FunctionTwo();


            //    Console.WriteLine();
            //    Console.WriteLine("Please press any Number for next request without zero");
            //    count=Convert.ToInt32(Console.ReadLine());
            //    container.clearScopedPull();
            //}

            Console.ReadKey();
        }

    }
}
