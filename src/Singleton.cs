namespace Virtualdars.DesignPatterns.Singleton
{
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        private Singleton()
        {
        }

        public static Singleton Instance()
        {
            return _instance;
        }

        public void DoSomething()
        {
            // ..
        }
    }

    public class Singleton2
    {
        public static Singleton2 Instance
        {
            get
            {
                return Nested.Singleton2;
            }
        }

        private class Nested
        {
            static Nested() { }
            internal static readonly Singleton2 Singleton2 = new Singleton2();
        }

        public void Initialize()
        {
            //...
        }
    }
}
