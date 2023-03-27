using Infrastructure.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Helpers
{
    public class ConnectionMapping
    {
        private readonly ConcurrentDictionary<string, HubConnectionInfo> _connections =
            new ConcurrentDictionary<string, HubConnectionInfo>();

        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }

        public void Add(string key, HubConnectionInfo info)
        {
            _connections.AddOrUpdate(key, info, (oldkey, oldvalue) => info);
        }

        public ICollection<HubConnectionInfo> GetAllClients()
        {
            return _connections.Values;
        }

        public HubConnectionInfo GetConnection(string key)
        {
            _connections.TryGetValue(key, out HubConnectionInfo info);
            return info;
        }

        public void Remove(string key)
        {
            _connections.TryRemove(key, out HubConnectionInfo info);
        }
    }
}
