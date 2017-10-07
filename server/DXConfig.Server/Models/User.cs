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
        public string Hash { get; }

        public User Create(string text)
        {
            string[] components = text.Split(":");

            if (components.Length != 3)
                return null;

            string provider = WebUtility.UrlDecode(components[0]);
            string name = WebUtility.UrlDecode(components[1]);
            string hash = components[2];

            return new User(provider, name, hash);
        }

        public User(string provider, string name, string hash)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (hash == null)
                throw new ArgumentNullException(nameof(hash));

            Provider = provider;
            Name = name;
            Hash = hash;
        }

        public override string ToString()
        {
            string provider = WebUtility.UrlEncode(Provider);
            string name = WebUtility.UrlEncode(Name);

            return $"{provider}:{name}:{Hash}";
        }
    }
}
