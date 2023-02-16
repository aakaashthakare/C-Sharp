///<summary>
/// Creational pattern
/// Ensure class has only one instance, and provide global point of access to it
/// E.g. Spring : singleton-scoped beans [default scope of bean is singleton]
/// Uses: to manage pools of resources like connections or thread pools
/// Database connections, Logging, Caching, Configuration, Thread pool, [Resource management] Access to shared resource, Factory Methods,
/// Application Context, Service Locators, Event Management, Dependency Injection [ Used as dependency in dependency management framework] 
/// </summary>

// Class itself responsible for keeping track of its sole instance
// The class can ensure that no other instance can be created by intercepting requests to create new objects
// and it can provide a  way to access the instance

// 1. Ensure single instance
// 2. Provide the way to access the instance: ACCESS POINT

// Lazy initialization: Creating the singleton instance only when it is first requested, rather than when the class is loaded.
// Important for resource intensive objects
// i.e lazyness is needed when class initialization does something particularly time-consuming
// When there are subclasses: Registry approach
// NO PUBLIC CONSTUCTOR 
// What if the object is resource intensive and our app never ends up using it ??

// Common characteristics of Singleton Pattern:
// 1. Private and parameterless single constructor
// 2. Sealed class. // Unnecessary as private constructor prevent subclassing but can help JIT to optimize
// 3. Static variable to hold a reference to the single created instance
// 4. A public and static way of getting the reference to the created instance.

//+---------------------+
//| Singleton           |
//+---------------------+
//| -UniqueInstance:Singleton
//| -SingletonClass()   |
//| +Instance()         |
//| +DoSomething()      |
//+---------------------+

using System;
namespace Design_Patterns
{
    public class Singleton
    {
        private static Singleton? UniqueInstance;

        private Singleton()
        {
        }

        // This is not thread-safe
        public static Singleton GetInstance()
        {
            if (UniqueInstance == null)
            {
                UniqueInstance = new Singleton();
            }
            return UniqueInstance;
        }

    }

    // Using Property
    //The Singleton should always be a 'sealed' class to prevent class inheritance
    public sealed class Singleton2
    {   
        private static Singleton2? UniqueInstance;

        private Singleton2()
        {
        }

        public static Singleton2 Instance
        {
            get
            {
                if (UniqueInstance == null)
                    UniqueInstance = new Singleton2();
                return UniqueInstance;
            }
        }

        public void DoSomething()
        {
            //Some business logic
        }
    }

    // Dounble checked locking
    public sealed class Singleton3
    {
        private static Singleton3? UniqueInstance;

        private static readonly object locker = new object();


        private Singleton3()
        {

        }
        private static Singleton3 Instance
        {
            get
            {
                if(UniqueInstance == null)
                {
                    lock (locker)
                    {
                        if(UniqueInstance == null)
                        {
                            UniqueInstance = new Singleton3();

                        }
                    }
                }
                return UniqueInstance;

            }
        }

        public void DoSomething()
        {
            //Some business logic
        }
    }

    public sealed class Singleton4
    {
        private static readonly Singleton4 UniqueInstance = new Singleton4();

        // static constructors in C# are specified to execute only when
        // an instance of the class is created or a static member is referenced,
        // and to execute only once per AppDomain. 
        static Singleton4()
        {

        }
        private Singleton4()
        {

        }
        public static Singleton4 Instance
        {
            get
            {
                return Instance;
            }
        }
    }

    // Simple and secure
    // Lazy initialization
    public sealed class Singleton5
    {
        private static readonly Lazy<Singleton5> lazy =
            new Lazy<Singleton5>(() => new Singleton5());

        public static Singleton5 Instance {
            get {
                return lazy.Value;
            }
        }

        private Singleton5()
        {
        }
    }

    // Early initialization
    public sealed class Singleton6
    {
        private static readonly Singleton6 instance = new Singleton6();

        private Singleton6()
        {
        }

        public static Singleton6 Instance
        {
            get
            {
                return instance;
            }
        }
    }

}

