using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public class UserKeyServices : PassKeyServices
    {
        public UserKeyServices(string secret)
            : base(Hash.Sha256(secret))
        {
        }

        public IPassKey Create(string provider, string username)
        {
            string value = $"{provider}:{username}";

            return base.Create(value);
        }
    }

    public abstract partial class PassKeyServices
    {
        IHash _calculate;

        protected PassKeyServices(IHash calculate)
        {
            _calculate = calculate;
        }

        protected IPassKey Create(string value)
        {
            return new HashKey(value, _calculate.Hash(value).Base64);
        }

        public bool ValidateKey(IPassKey key)
        {
            if (key == null)
                return false;

            string value = key.Value;
            string hash = key.Hash;

            return (hash == _calculate.Hash(value).Base64);
        }
    }
}
