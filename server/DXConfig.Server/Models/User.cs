using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace DXConfig.Server.Models
{
    public class User
    {
        public string Provider { get; }
        public string Name { get; }
        public IPassKey Key { get; }
        
        public User(string provider, string name, IPassKey key)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            Provider = provider;
            Name = name;
            Key = key;
        }

        public override string ToString()
        {
            return $"{Provider}:{Name}";
        }
    }
}
