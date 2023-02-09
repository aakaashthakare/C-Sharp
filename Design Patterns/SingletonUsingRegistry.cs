using System;
namespace Design_Patterns
{

    public abstract class Book
    {
        protected Book() { }

        private Book(Type type) { }

        private static readonly Dictionary<Type, Book> Registry = new Dictionary<Type, Book>();

        public static T GetInstance<T>() where T : Book, new()
        {
            if (!Registry.ContainsKey(typeof(T)))
            {
                Registry[typeof(T)] = new T();
            }
            return (T)Registry[typeof(T)];
        }
    }
    public class Paperback : Book
    {
        protected Paperback() { }

        // Additional properties and methods specific to Paperback
    }

    //public class SingletonUsingRegistry
    //{
    //	public SingletonUsingRegistry()
    //	{
    //	}
    //	static void Main(string []args)
    //	{
    //		var  fictionBook1 = FictionBook.GetInstance<FictionBook>();
    //		FictionBook fictionBook2 = FictionBook.GetInstance<FictionBook>();
    //		NonFictionBook nonFictionBook1 = NonFictionBook.GetInstance<NonFictionBook>();
    //           NonFictionBook nonFictionBook2 = NonFictionBook.GetInstance<NonFictionBook>();
    //		if(fictionBook1 ==  fictionBook2 && nonFictionBook1 == nonFictionBook2)
    //		{
    //			Console.WriteLine("Singeton is working...");
    //		}
    //		fictionBook1.Say();
    //		nonFictionBook1.Say();
    //       }

    //}

    //public abstract class Book
    //{
    //	private static readonly Dictionary<string, Book> registry
    //		= new Dictionary<string, Book>();
    //	private static readonly object locker = new object();
    //	protected Book()
    //	{

    //	}
    //       public static T GetInstance<T>() where T : Book, new()
    //       {
    //           Type type = typeof(T);
    //		string key = System.Convert.ToString(type) ?? "DefaultBook";
    //           if (!registry.ContainsKey(key))
    //           {
    //               lock (locker)
    //               {
    //                   if (!registry.ContainsKey(key))
    //                   {
    //					if (key.Equals("DefaultBook"))
    //					{
    //                           registry[key] = new T();
    //                       }
    //					else
    //					{
    //						registry[key] = new T();
    //					}
    //                   }
    //               }
    //           }
    //           return (T)registry[key];
    //       }
    //   }

    //public class DefaultBook: Book
    //{


    //}

    //public class FictionBook : Book
    //{
    //	protected FictionBook()
    //	{

    //	}
    //	public void Say()
    //	{
    //		Console.WriteLine("This is fiction book..");
    //	}
    //}

    //public class NonFictionBook: Book
    //{
    //	protected NonFictionBook()
    //	{

    //	}
    //       public void Say()
    //       {
    //           Console.WriteLine("This is non-fiction book..");
    //       }

    //   }

}

