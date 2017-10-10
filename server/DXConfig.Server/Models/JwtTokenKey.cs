using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Models
{
    public class JwtTokenKey : HashKey
    {
        public JwtTokenKey(string value, string hash) : base(value, hash)
        { }

        public override string ToString()
        {
            return $"{Value}.{Hash}";
        }
    }
}
