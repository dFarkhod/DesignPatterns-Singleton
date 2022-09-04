using static System.Console;

namespace Virtualdars.DesignPatterns.Singleton
{
    public class Program
    {
        public static void Main()
        {
            // singletondagi metodlarni to'g'ridan-to'g'ri chaqirish:
            Singleton.Instance().DoSomething();
            Singleton2.Instance.Initialize();

            // alohida o'zgaruvchi olib ishlatish:
            var inst = Singleton.Instance();
            inst.DoSomething();

            // signletonning barcha instance'larining hammasi bitta ekanligini tekshirish:
            var inst1 = Singleton.Instance();
            var inst2 = Singleton.Instance();

            if (inst1 == inst2)
            {
                WriteLine("the same instance!");
            }

            // signleton instance'larini tekshirish:
            var inst3 = Singleton2.Instance;
            var inst4 = Singleton2.Instance;

            if (inst3 == inst4)
            {
                WriteLine("the same instance!");
            }

            WriteLine();


            // Hayotiy misollar:
            WriteLine("Random Load Balancer...");
            for (int i = 0; i < 10; i++)
            {
                string serverName = RandomLoadBalancer.GetLoadBalancer().NextServer.Name;
                WriteLine($"So'rov {serverName} ga jo'natildi.");
            }

            WriteLine();

            WriteLine("Round Robin Load Balancer...");
            for (int i = 0; i < 10; i++)
            {
                string serverName = RoundRobinLoadBalancer.GetLoadBalancer().NextServer.Name;
                WriteLine($"So'rov {serverName} ga jo'natildi.");
            }

            ReadLine();
        }
    }
}

