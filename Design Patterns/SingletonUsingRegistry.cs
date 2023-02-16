using System;
namespace Design_Patterns
{

	public class SingletonUsingRegistry
	{
		public SingletonUsingRegistry()
		{
		}
		static void Main(string []args)
		{
			Book fictionBook1 = Book.GetInstance<FictionBook>();
            FictionBook fictionBook2 = Book.GetInstance<FictionBook>();
            NonFictionBook nonFictionBook1 = NonFictionBook.GetInstance<NonFictionBook>();
            NonFictionBook nonFictionBook2 = NonFictionBook.GetInstance<NonFictionBook>();
			if(fictionBook1 ==  fictionBook2 && nonFictionBook1 == nonFictionBook2)
			{
				Console.WriteLine("Singeton is working...");
			}
			fictionBook1.Say();
			nonFictionBook1.Say();
        }
		
	}

	public abstract class Book
	{
		private static readonly Dictionary<string, Book> registry
			= new Dictionary<string, Book>();
		private static readonly object locker = new object();
		protected Book()
		{

		}
        public static T GetInstance<T>() where T : Book, new()
        {
            Type type = typeof(T);
			string key = System.Convert.ToString(type) ?? "DefaultBook";
            if (!registry.ContainsKey(key))
            {
                lock (locker)
                {
                    if (!registry.ContainsKey(key))
                    {
						if (key.Equals("DefaultBook"))
						{
                            registry[key] = CreateInstance<T>();
                        }
						else
						{
							registry[key] = CreateInstance<T>();
                        }
                    }
                }
            }
            return (T)registry[key];
        }

        private static T CreateInstance<T>() where T : Book, new()
        {
            return new T();
        }

		public abstract void Say();
    }

    public class DefaultBook : Book
    {
        public override void Say()
        {
            Console.WriteLine("This is default book..");
        }
    }

    public class FictionBook : Book
	{
        public override void Say()
		{
			Console.WriteLine("This is fiction book..");
		}
	}

	public class NonFictionBook: Book
	{
        public override void Say()
        {
            Console.WriteLine("This is non-fiction book..");
        }

    }

}

