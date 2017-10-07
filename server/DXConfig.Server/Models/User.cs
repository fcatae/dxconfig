using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace DXConfig.Server.Models
{
    public class User : IUser
    {
        public string Provider { get; }
        public string Name { get; }
        public IPassKey Key { get; }
        public IPassKey ExtraKey { get; private set; }

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

        public void SetPassword(IPassKey passwordKey)
        {
            ExtraKey = passwordKey;
        }

        public override string ToString()
        {
            return $"{Provider}:{Name}";
        }
    }
}
