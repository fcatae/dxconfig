using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Models
{
    public class HashKey : IPassKey
    {
        public string Value { get; }

        public string Hash { get; }
        
        public HashKey(string value, string hash)
        {
            this.Value = value;
            this.Hash = hash;
        }

        public override string ToString()
        {
            return "{Value}:{Hash}";
        }
    }
}
