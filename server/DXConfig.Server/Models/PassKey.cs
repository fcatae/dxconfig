using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Models
{
    public class PassKey : HashKey
    {
        public PassKey(string value, string secret, string hash) : base(value, hash)
        {
            Secret = secret;
        }

        public string Secret { get; }
    }
}
