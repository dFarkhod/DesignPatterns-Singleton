using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtualdars.DesignPatterns.Singleton
{
    public sealed class RoundRobinLoadBalancer
    {
        private static readonly RoundRobinLoadBalancer _instance = new RoundRobinLoadBalancer();

        private readonly ConcurrentQueue<Server> _servers = new ConcurrentQueue<Server>();

        private RoundRobinLoadBalancer()
        {
            _servers.Enqueue(new Server { Name = "ServerA", IPAddress = "110.1.33.1" });
            _servers.Enqueue(new Server { Name = "ServerB", IPAddress = "110.1.33.7" });
            _servers.Enqueue(new Server { Name = "ServerC", IPAddress = "110.1.33.9" });
            _servers.Enqueue(new Server { Name = "ServerD", IPAddress = "110.1.33.11" });
            _servers.Enqueue(new Server { Name = "ServerE", IPAddress = "110.1.33.17" });
        }

        public static RoundRobinLoadBalancer GetLoadBalancer()
        {
            return _instance;
        }


        public Server NextServer
        {
            get
            {
                Server server;
                if (_servers.TryDequeue(out server))
                {
                    _servers.Enqueue(server);
                }
                return server;
            }
        }
    }
}
