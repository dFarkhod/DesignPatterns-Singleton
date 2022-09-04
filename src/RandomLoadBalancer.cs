using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtualdars.DesignPatterns.Singleton
{
    public sealed class RandomLoadBalancer
    {
        private static readonly RandomLoadBalancer _instance = new RandomLoadBalancer();

        private readonly List<Server> _servers;
        private readonly Random _random = new Random();

        private RandomLoadBalancer()
        {

            _servers = new List<Server>
                {
                  new Server{ Name = "ServerA", IPAddress = "110.1.33.1" },
                  new Server{ Name = "ServerB", IPAddress = "110.1.33.7" },
                  new Server{ Name = "ServerC", IPAddress = "110.1.33.9" },
                  new Server{ Name = "ServerD", IPAddress = "110.1.33.11" },
                  new Server{ Name = "ServerE", IPAddress = "110.1.33.17" },
                };
        }

        public static RandomLoadBalancer GetLoadBalancer()
        {
            return _instance;
        }


        public Server NextServer
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }

   
}
