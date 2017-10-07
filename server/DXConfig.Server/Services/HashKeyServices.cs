using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public class HashKeyServices : IPassKeyServices
    {
        HashAlgorithm _encryptionKey;

        public HashKeyServices(string secret)
        {
            _encryptionKey = CreateEncryptionKey(secret);            
        }

        public IPassKey Create(string value)
        {
            return new HashKey(value, Hash(value));
        }

        public bool ValidateKey(IPassKey key)
        {
            var otherKey = key as HashKey;

            if (otherKey == null)
                return false;

            string value = otherKey.Value;
            string hash = otherKey.Hash;

            return ( hash == Hash(value) );
        }

        string Hash(string value)
        {
            byte[] data = Encoding.UTF8.GetBytes(value);

            byte[] hash = _encryptionKey.ComputeHash(data);

            return Convert.ToBase64String(hash);
        }        

        HashAlgorithm CreateEncryptionKey(string secret)
        {
            var key = Encoding.UTF8.GetBytes(secret);
            HMACSHA256 hmacSha = new HMACSHA256(key);
            
            return hmacSha;
        }
    }
}
